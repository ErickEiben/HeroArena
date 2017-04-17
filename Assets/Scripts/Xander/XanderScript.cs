﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class XanderScript : MonoBehaviour {
	public static XanderScript S;

	public InputDevice Device { get; set; }

	#region Variables
	[Header ("Adjustable Variables")]
	[Range (0, 10)] public float speed = 0f;
	private float rotateChar = 12f;

	[Header ("Settable Variables")]
	public Animation playerAnim;
	public GameObject playerBody;
	public GameObject playerParent;
	[HideInInspector] public bool canMove = true;

	// Private Static Variables
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 headDirection = Vector3.zero;

	[Header ("Xander Statistics")]
	public float maxHealth;
	public float maxStamina;
	private float curHealth;
	private float curStamina;

	[Header ("Xander Basic Attack Variables")]
	[Range (0, 100)] public float xanderBasicDamage;
	[Range (0, 10)] public float xanderBasicCD;
	public float xanderBasicSpeed = .5f;
	private bool basicCooling;

	[Header ("Xander Mine Variables")]
	[Range (0, 100)] public float xanderMineDamage;
	[Range (0, 10)] public float xanderMineCD;
	public float xanderMineSpeed;
	private bool mineCooling;

	/*
	[Header ("Xander Ultimate Variables")]
	[Range (0, 250)] public float xanderUltDamage;
	[Range (0, 120)] public float xanderUltCD;
	public float xanderUltSpeed;
	private bool ultCooling;
	*/

	[Header ("Xander Dig Variables")]
	[Range (0, 2)] public float xanderDigDistance;
	[Range (0, 10)] public float xanderDigCD;
	public float xanderDigSpeed;
	private bool digCooling;

	[Header ("Xander Various")]
	public GameObject basicSpawnPoint;
	public GameObject mineSpawnPoint;
	#endregion

	void Awake () {
		S = this;
	}

	void Start () {
	}

	void Update () {

		if (Device != null) {

			#region *** XANDER BASIC ATTACK ***
			if (basicCooling) {
				xanderBasicCD -= Time.deltaTime;

				if (xanderBasicCD <= 0f) {
					basicCooling = false;
					xanderBasicCD = xanderBasicSpeed;
				}
			}

			if (Device.RightBumper.IsPressed) {
				if (basicCooling == false)
					xanderBasic (playerBody);
				playerAnim.Play ("Attack");
			}
			#endregion

			#region *** XANDER MINE ATTACK ***
			if (mineCooling) {
				xanderMineCD -= Time.deltaTime;

				if (xanderMineCD <= 0f) {
					mineCooling = false;
					xanderMineCD = xanderMineSpeed;
				}
			}

			if (Device.DPadDown.IsPressed) {
				if (mineCooling == false)
					xanderMine (playerBody);
				playerAnim.Play ("Ability 1");
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

			if (Device.DPadUp.IsPressed) {
				this.transform.position += playerBody.transform.forward * xanderDigDistance;
			}
			#endregion

			if (canMove) {
				// Moving and rotating the character with the left stick
				CharacterController Controller = GetComponent<CharacterController> ();

				moveDirection = new Vector3 (Device.LeftStickX, 0, Device.LeftStickY);
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;

				if (moveDirection != Vector3.zero && headDirection == Vector3.zero) {
					playerBody.transform.rotation = Quaternion.Slerp (
						playerBody.transform.rotation,
						Quaternion.LookRotation (moveDirection),
						Time.deltaTime * rotateChar);
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
				playerAnim.Play ("Idle");
			}
			if (moveDirection != Vector3.zero) {
				playerAnim.Play ("Run");
			}
		}
	}

	public void xanderBasic (GameObject thisPlayer) {
		basicCooling = true;
		GameObject creation;
		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y - 2, creation.transform.eulerAngles.x);
		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y, creation.transform.eulerAngles.x);
		creation = Instantiate (Resources.Load ("XanderGrenade"), basicSpawnPoint.transform.position, basicSpawnPoint.transform.rotation) as GameObject;
		creation.transform.eulerAngles = new Vector3 (creation.transform.eulerAngles.x, creation.transform.eulerAngles.y + 2, creation.transform.eulerAngles.x);
	}

	public void xanderMine (GameObject thisPlayer) {
		mineCooling = true;
		canMove = false;
		GameObject creation;
		creation = Instantiate (Resources.Load ("XanderMine"), mineSpawnPoint.transform.position, mineSpawnPoint.transform.rotation) as GameObject;
		playerAnim.Play ("Ability 1");
		canMove = true;
	}
}