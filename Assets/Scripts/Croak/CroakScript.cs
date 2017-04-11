﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CroakScript : MonoBehaviour {
	public static CroakScript S;

	public InputDevice Device { get; set; }

	#region Variables
	[Header ("Adjustable Variables")]
	[Range (0, 10)] public float speed = 0f;
	private float rotateChar = 12f;

	[Header ("Settable Variables")]
	public Animation playerAnim;
	public GameObject playerBody;
	public GameObject playerParent;
	[HideInInspector]
	public bool canMove = true;

	// Private Static Variables
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 headDirection = Vector3.zero;

	[Header ("Croak Statistics")]
	public float maxHealth;
	public float maxStamina;
	private float curHealth;
	private float curStamina;

	[Header ("Croak Basic Attack Variables")]
	[Range (0, 100)] public float croakBasicDamage;
	[Range (0, 10)] public float croakBasicCD;
	public float croakBasicSpeed = .5f;
	private bool basicCooling;
	#endregion

	void Awake () {
		S = this;
	}

	void Update () {

		if (Device != null) {
			if (basicCooling) {
				croakBasicCD -= Time.deltaTime;

				if (croakBasicCD <= 0f) {
					basicCooling = false;
					croakBasicCD = croakBasicSpeed;
				}
			}

			if (Device.RightBumper.IsPressed) {
				if (basicCooling == false)
					croakBasic (playerBody);
				playerAnim.Play ("Attack V1");
			}

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
				playerAnim.Play ("Nothing Idle");
			}
			if (moveDirection != Vector3.zero) {
				playerAnim.Play ("Run");
			}
		}
	}

	public void croakBasic (GameObject thisPlayer) {
		basicCooling = true;
		//GameObject creation;
	}

}
