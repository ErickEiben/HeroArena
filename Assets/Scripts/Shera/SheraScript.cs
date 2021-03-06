﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class SheraScript : MonoBehaviour
{
	public static SheraScript S;

	public InputDevice Device { get; set; }

	#region Variables

	[Header ("----- Adjustable Variables -----")]
	[Range (0, 10)] public float speed = 0f;
	private float rotateChar = 12f;

	[Header ("----- Settable Variables -----")]
	public Animator anim;
	private float inputH;
	private float inputV;
	public GameObject playerBody;
	public GameObject playerParent;
	public GameObject basicSpawnPoint;
	public GameObject doubleKickIndicator;
	public GameObject dancingLeapIndicator;
	[HideInInspector] public bool canMove = true;

	// Private Static Variables
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 headDirection = Vector3.zero;

	[Header ("----- Shera Statistics -----")]
	public float maxHealth;
	public float maxStamina;
	private float curHealth;
	private float curStamina;

	[Header ("----- Shera Basic Attack Variables -----")]
	[Range (0, 100)] public float sheraBasicDamage;
	[Range (0, 10)] public float sheraBasicCD;
	[Range (0, 1)] public float sheraBasicRange;
	public float sheraBasicSpeed;
	private bool sheraBasicCooling;

	[Header ("----- Shera Double Kick Variables -----")]
	[Range (0, 100)] public float sheraDoubleKickDamage;
	[Range (0, 1)] public float sheraDoubleKickSlow;
	[Range (0, 5)] public float sheraDoubleKickSlowLength;
	[Range (0, 10)] public float sheraDoubleKickCD;
	[Range (0, 1)] public float sheraDoubleKickRange;
	public float sheraDoubleKickSpeed;
	private bool sheraDoubleKickCooling;

	[Header ("----- Shera Dancing Leap Variables -----")]
	[Range (0, 100)] public float sheraDancingLeapDamage;
	[Range (0, 10)] public float sheraDancingLeapDistance;
	[Range (0, 10)] public float sheraDancingLeapCD;
	[Range (0, 1)] public float sheraDancingLeapRange;
	public float sheraDancingLeapSpeed;
	private bool sheraDancingLeapCooling;

	[Header ("----- Shera Miscellaneous Variables -----")]
	HealthBarScript healthBarScript;
	CollisionTriggerScript collisionTriggerScript;
	CollisionTriggerScript collisionTriggerScript2;
	public float coneAngle = 45f;
	[HideInInspector] public bool sheraSlowed = false;
	[HideInInspector] public float sheraSlowedAmount;
	[HideInInspector] public float sheraSlowedLength;
	public int team;
	[HideInInspector] public int playerPosition;
	[HideInInspector] public bool isDead = false;

	#endregion

	void Awake ()
	{
		S = this;
		this.gameObject.name = "Shera";
	}

	void Start ()
	{
		anim = GetComponent<Animator> ();
		collisionTriggerScript = doubleKickIndicator.GetComponent<CollisionTriggerScript> ();
		collisionTriggerScript2 = dancingLeapIndicator.GetComponent<CollisionTriggerScript> ();
		doubleKickIndicator.SetActive (false);
		dancingLeapIndicator.SetActive (false);
	}

	void Update ()
	{
		if (isDead == true) {
			canMove = false;
			this.GetComponent<BoxCollider> ().enabled = false;
			this.GetComponent<CharacterController> ().enabled = false;
			anim.Play ("Death");
			if (playerPosition == 0) {
				DataManager.S.player1Dead = true;
			} else if (playerPosition == 1) {
				DataManager.S.player2Dead = true;
			}  else if (playerPosition == 2) {
				DataManager.S.player3Dead = true;
			}  else if (playerPosition == 3) {
				DataManager.S.player4Dead = true;
			}
		}

		this.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

		if (Device != null) {

			#region *** SHERA SLOW DURATION ***
			if (sheraSlowed) {
				sheraSlowedLength -= Time.deltaTime;

				if (sheraSlowedLength <= 0f) {
					sheraSlowed = false;
					canMove = true;
					sheraSlowedAmount = 0f;
					sheraSlowedLength = 0f;
				}
			}
			#endregion

			if (canMove) {
				
				#region *** SHERA BASIC ATTACK ***
				if (sheraBasicCooling) {
					sheraBasicCD -= Time.deltaTime;

					if (sheraBasicCD <= 0f) {
						sheraBasicCooling = false;
						sheraBasicCD = sheraBasicSpeed;
					}
				}

				if (Device.RightBumper.WasPressed) {
					if (sheraBasicCooling == false) {
						sheraBasic (sheraBasicRange);
						anim.Play ("Basic Attack", -1, 0f);
					}
				}
				#endregion

				#region  *** SHERA DANCING LEAP ***
				if (sheraDancingLeapCooling) {
					sheraDancingLeapCD -= Time.deltaTime;

					if (sheraDancingLeapCD <= 0f) {
						sheraDancingLeapCooling = false;
						sheraDancingLeapCD = sheraDancingLeapSpeed;
					}
				}

				if (Device.Action1.WasPressed) {
					if (sheraDancingLeapCooling == false) {
						if (dancingLeapIndicator.activeSelf == false) {
							dancingLeapIndicator.SetActive (true);
						} else if (dancingLeapIndicator.activeSelf == true) {
							sheraDancingLeap (sheraDancingLeapRange);
							anim.Play ("Ability 1", -1, 0f);
							dancingLeapIndicator.SetActive (false);
						}
					}
				}
				#endregion

				#region *** SHERA DOUBLE KICK ***
				if (sheraDoubleKickCooling) {
					sheraDoubleKickCD -= Time.deltaTime;

					if (sheraDoubleKickCD <= 0f) {
						sheraDoubleKickCooling = false;
						sheraDoubleKickCD = sheraDoubleKickSpeed;
					}
				}

				if ((Device.LeftBumper.WasPressed)) {
					if (sheraDoubleKickCooling == false) {
						if (doubleKickIndicator.activeSelf == false) {
							doubleKickIndicator.SetActive (true);
						} else if (doubleKickIndicator.activeSelf == true) {
							sheraDoubleKick (sheraDoubleKickRange);
							anim.Play ("Ability 2", -1, 0f);
							doubleKickIndicator.SetActive (false);
						}
					}
				}
				#endregion

				// Moving and rotating the character with the left stick
				CharacterController Controller = GetComponent<CharacterController> ();

				if (sheraSlowed == false) {
					moveDirection = new Vector3 (Device.LeftStickX, 0, Device.LeftStickY);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed;

					if (moveDirection != Vector3.zero && headDirection == Vector3.zero) {
						playerBody.transform.rotation = Quaternion.Slerp (
							playerBody.transform.rotation,
							Quaternion.LookRotation (moveDirection),
							Time.deltaTime * rotateChar);
					}
				}

				if (sheraSlowed == true) {
					moveDirection = new Vector3 (Device.LeftStickX, 0, Device.LeftStickY);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed - sheraSlowedAmount;

					if (moveDirection != Vector3.zero && headDirection == Vector3.zero) {
						playerBody.transform.rotation = Quaternion.Slerp (
							playerBody.transform.rotation,
							Quaternion.LookRotation (moveDirection),
							Time.deltaTime * rotateChar);
					}
				}

				// Rotating the character with the right stick
				headDirection = new Vector3 (Device.RightStick.X, 0, Device.RightStick.Y);
				if (headDirection != Vector3.zero) {
					playerBody.transform.parent = playerParent.transform;
					playerBody.transform.rotation = Quaternion.Slerp (
						playerBody.transform.rotation,
						Quaternion.LookRotation (headDirection),
						Time.deltaTime * rotateChar);
				}

				Controller.Move (moveDirection * Time.deltaTime);
			}

			// Playing animations
			if (moveDirection == Vector3.zero) {
				anim.SetFloat ("inputH", 0);
				anim.SetFloat ("inputV", 0);
			}
			if (moveDirection != Vector3.zero) {
				inputH = 0;
				inputV = 1;
				anim.SetFloat ("inputH", inputH);
				anim.SetFloat ("inputV", inputV);
			}
		}
	}

	public void sheraBasic (float sheraBasicRange)
	{
		sheraBasicCooling = true;
		Vector3 explosionPos = basicSpawnPoint.transform.position;
		Collider[] hitColliders = Physics.OverlapSphere (explosionPos, sheraBasicRange);

		foreach (Collider hit in hitColliders) {
			if ((hit.GetComponent<Collider> ().tag == "Player") && (hit.gameObject != playerParent.gameObject)) {
				healthBarScript = hit.transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
				healthBarScript.GetHit (sheraBasicDamage);
			}
		}
	}

	public void sheraDoubleKick (float sheraBasicRange)
	{
		sheraDoubleKickCooling = true;
		if (collisionTriggerScript.triggered == true) {
			for (int i = 0; i < collisionTriggerScript.targets.Count; i++) {
				healthBarScript = collisionTriggerScript.targets[i].transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
				healthBarScript.GetHit (sheraDoubleKickDamage);
				if (collisionTriggerScript.targets[i].name == "Xander") {
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().xanderSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().xanderSlowedAmount += sheraDoubleKickSlow;
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().xanderSlowedLength += sheraDoubleKickSlowLength;
				}
				if (collisionTriggerScript.targets[i].name == "Shera") {
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().sheraSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().sheraSlowedAmount += sheraDoubleKickSlow;
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().sheraSlowedLength += sheraDoubleKickSlowLength;
				}
				if (collisionTriggerScript.targets[i].name == "Croak") {
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().croakSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().croakSlowedAmount += sheraDoubleKickSlow;
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().croakSlowedLength += sheraDoubleKickSlowLength;
				}
				if (collisionTriggerScript.targets[i].name == "Jeremiah") {
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().jeremiahSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().jeremiahSlowedAmount += sheraDoubleKickSlow;
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().jeremiahSlowedLength += sheraDoubleKickSlowLength;
				}
			}
			collisionTriggerScript.targets.Clear();
		}
	}

	public void sheraDancingLeap (float sheraDancingLeapRange)
	{
		sheraDancingLeapCooling = true;
		this.transform.position = dancingLeapIndicator.transform.position;

		if (collisionTriggerScript2.triggered == true) {
			for (int i = 0; i < collisionTriggerScript2.targets.Count; i++) {
				healthBarScript = collisionTriggerScript2.targets[i].transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
				healthBarScript.GetHit (sheraDancingLeapDamage);
			}
		}
		collisionTriggerScript2.targets.Clear();

	}
} 