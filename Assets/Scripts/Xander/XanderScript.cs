﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class XanderScript : MonoBehaviour
{
	public static XanderScript S;

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
	public GameObject digIndicator;
	[HideInInspector] public bool canMove = true;

	// Private Static Variables
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 headDirection = Vector3.zero;

	[Header ("----- Xander Statistics -----")]
	public float maxHealth;
	public float maxStamina;
	private float curHealth;
	private float curStamina;

	[Header ("----- Xander Basic Attack Variables -----")]
	[Range (0, 100)] public float xanderBasicDamage;
	[Range (0, 10)] public float xanderBasicCD;
	public float xanderBasicSpeed = .5f;
	private bool basicCooling;

	[Header ("----- Xander Mine Variables -----")]
	[Range (0, 100)] public float xanderMineDamage;
	[Range (0, 10)] public float xanderMineCD;
	public float xanderMineSpeed;
	private bool mineCooling;

	private bool mineAnim = false;
	private float mineAnimCD = 1.5f;
	private float mineAnimSpeed = 1.5f;

	[Header ("----- Xander Dig Variables -----")]
	[Range (0, 10)] public float xanderDigDistance;
	[Range (0, 10)] public float xanderDigCD;
	public float xanderDigSpeed;
	private bool digCooling;

	[Header ("----- Xander Miscellaneous Variables -----")]
	public GameObject basicSpawnPoint;
	public GameObject mineSpawnPoint;
	CollisionTriggerScript collisionTriggerScript;
	GrenadeScript grenadeScript;
	[HideInInspector] public bool xanderSlowed = false;
	[HideInInspector] public float xanderSlowedAmount;
	[HideInInspector] public float xanderSlowedLength;
	public int team;
	[HideInInspector] public int playerPosition;
	[HideInInspector] public bool isDead = false;

	#endregion

	void Awake ()
	{
		S = this;
		this.gameObject.name = "Xander";
	}

	void Start ()
	{
		anim = GetComponent<Animator> ();
		collisionTriggerScript = digIndicator.GetComponent<CollisionTriggerScript> ();
		digIndicator.SetActive (false);
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

			#region *** XANDER SLOW DURATION ***
			if (xanderSlowed) {
				xanderSlowedLength -= Time.deltaTime;

				if (xanderSlowedLength <= 0f) {
					xanderSlowed = false;
					canMove = true;
					xanderSlowedAmount = 0f;
					xanderSlowedLength = 0f;
				}
			}

			if (mineAnim) {
				mineAnimCD -= Time.deltaTime;

				if (mineAnimCD <= 0f) {
					mineAnim = false;
					canMove = true;
					mineAnimCD = mineAnimSpeed;
				}
			}
			#endregion

			if (canMove) {
				#region *** XANDER BASIC ATTACK ***
				if (basicCooling) {
					xanderBasicCD -= Time.deltaTime;

					if (xanderBasicCD <= 0f) {
						basicCooling = false;
						xanderBasicCD = xanderBasicSpeed;
					}
				}

				if (Device.RightBumper.WasPressed) {
					if (basicCooling == false) {
						xanderBasic (playerBody);
						anim.Play ("Basic Attack", -1, 0f);
					}
				}
				#endregion

				#region *** XANDER MINE ATTACK ***
				if (mineCooling) {
					xanderMineCD -= Time.deltaTime;

					if (xanderMineCD <= 0f) {
						mineCooling = false;
						canMove = true;
						xanderMineCD = xanderMineSpeed;
					}
				}

				if (Device.LeftBumper.WasPressed) {
					if (mineCooling == false) {
						xanderMine (playerBody);
						mineAnim = true;
						canMove = false;
						anim.Play ("Ability 1", -1, 0f);
					}
				}
				#endregion

				#region *** XANDER DIG ABILITY ***
				if (digCooling) {
					xanderDigCD -= Time.deltaTime;

					if (xanderDigCD <= 0f) {
						digCooling = false;
						xanderDigCD = xanderDigSpeed;
					}
				}

				if (Device.Action1.WasPressed) {
					if (digCooling == false) {
						if (digIndicator.activeSelf == false) {
							digIndicator.SetActive (true);
						} else if ((digIndicator.activeSelf == true) && (collisionTriggerScript.targets.Count == 0)) {
							this.transform.position	= digIndicator.transform.position;
							digCooling = true;
							anim.Play ("Ability 2A", -1, 0f);
							digIndicator.SetActive (false);
							collisionTriggerScript.targets.Clear();
						}
					}
				}
				#endregion

				// Moving and rotating the character with the left stick
				CharacterController Controller = GetComponent<CharacterController> ();

				if (xanderSlowed == false) {
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

				if (xanderSlowed == true) {
					moveDirection = new Vector3 (Device.LeftStickX, 0, Device.LeftStickY);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed - xanderSlowedAmount;

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

	public void xanderBasic (GameObject thisPlayer)
	{
		basicCooling = true;
		GameObject creation;
		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y - 2, creation.transform.eulerAngles.x);
		Physics.IgnoreCollision (creation.GetComponent<Collider>(), this.GetComponent<Collider>());
		grenadeScript = creation.GetComponent<GrenadeScript> ();
		grenadeScript.parent = this.gameObject;

		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y, creation.transform.eulerAngles.x);
		Physics.IgnoreCollision (creation.GetComponent<Collider>(), this.GetComponent<Collider>());
		grenadeScript = creation.GetComponent<GrenadeScript> ();
		grenadeScript.parent = this.gameObject;

		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y + 2, creation.transform.eulerAngles.x);
		Physics.IgnoreCollision (creation.GetComponent<Collider>(), this.GetComponent<Collider>());
		grenadeScript = creation.GetComponent<GrenadeScript> ();
		grenadeScript.parent = this.gameObject;
	}

	public void xanderMine (GameObject thisPlayer)
	{
		mineCooling = true;
		canMove = false;
		GameObject creation;
		creation = Instantiate (Resources.Load ("XanderMine"), mineSpawnPoint.transform.position, mineSpawnPoint.transform.rotation) as GameObject;
		Physics.IgnoreCollision (creation.GetComponent<Collider> (), this.GetComponent<Collider> ());
		canMove = true;
	}
}