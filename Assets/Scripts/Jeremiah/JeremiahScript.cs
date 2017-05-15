using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class JeremiahScript : MonoBehaviour
{
	public static JeremiahScript S;

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
	public GameObject crimsonReachSpawnPoint;
	public GameObject crimsonReachIndicator;
	[HideInInspector] public bool canMove = true;

	// Private Static Variables
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 headDirection = Vector3.zero;

	[Header ("----- Jeremiah Statistics -----")]
	public float maxHealth;
	public float maxStamina;
	private float curHealth;
	private float curStamina;

	[Header ("----- Jeremiah Basic Attack Variables -----")]
	[Range (0, 100)] public float jeremiahBasicDamage;
	[Range (0, 10)] public float jeremiahBasicCD;
	[Range (0, 1)] public float jeremiahBasicRange;
	public float jeremiahBasicSpeed;
	private bool jeremiahBasicCooling;

	[Header ("----- Jeremiah Inner Blood Variables -----")]
	[Range (0, 100)] public float jeremiahInnerBloodDamage;
	[Range (0, 10)] public float jeremiahInnerBloodCD;
	[Range (0, 1)] public float jeremiahInnerBloodRange;
	public float jeremiahInnerBloodSpeed;
	private bool jeremiahInnerBloodCooling;
	public bool innerBlood = false;

	[Header ("----- Jeremiah Crimson Reach Variables -----")]
	[Range (0, 10)] public float jeremiahCrimsonReachCD;
	[Range (0, 10)] public float jeremiahCrimsonReachRange;
	[Range (0, 1)] public float jeremiahCrimsonReachSlow;
	[Range (0, 5)] public float jeremiahCrimsonReachSlowLength;
	public float jeremiahCrimsonReachSpeed;
	private bool jeremiahCrimsonReachCooling;

	[Header ("----- Jeremiah Miscellaneous Variables -----")]
	public float slimConeAngle;
	public float wideConeAngle;
	CollisionTriggerScript collisionTriggerScript;
	HealthBarScript healthBarScript;
	[HideInInspector] public bool jeremiahSlowed = false;
	[HideInInspector] public float jeremiahSlowedAmount;
	[HideInInspector] public float jeremiahSlowedLength;
	public int team;
	[HideInInspector] public int playerPosition;
	[HideInInspector] public bool isDead = false;

	#endregion

	void Awake ()
	{
		S = this;
		this.gameObject.name = "Jeremiah";
	}

	void Start ()
	{
		anim = GetComponent<Animator> ();
		collisionTriggerScript = crimsonReachIndicator.GetComponent<CollisionTriggerScript> ();
		crimsonReachIndicator.SetActive (false);
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

			#region *** JEREMIAH SLOW DURATION ***
			if (jeremiahSlowed) {
				jeremiahSlowedLength -= Time.deltaTime;

				if (jeremiahSlowedLength <= 0f) {
					jeremiahSlowed = false;
					canMove = true;
					jeremiahSlowedAmount = 0f;
					jeremiahSlowedLength = 0f;
				}
			}
			#endregion

			if (canMove) {

				#region *** JEREMIAH BASIC ATTACK ***
				if (jeremiahBasicCooling) {
					jeremiahBasicCD -= Time.deltaTime;

					if (jeremiahBasicCD <= 0f) {
						jeremiahBasicCooling = false;
						jeremiahBasicCD = jeremiahBasicSpeed;
					}
				}

				if ((Device.RightBumper.WasPressed)) {
					if ((jeremiahBasicCooling == false) && (innerBlood == false)) {
						jeremiahBasic (jeremiahBasicRange);
						anim.Play ("Basic Attack 1", -1, 0f);
					} else if ((jeremiahInnerBloodCooling == false) && (innerBlood == true)) {
						jeremiahInnerBlood (jeremiahInnerBloodRange);
						anim.Play ("Basic Attack 2", -1, 0f);
					}
				}
				#endregion

				#region *** JEREMIAH INNER BLOOD ***
				if (jeremiahInnerBloodCooling) {
					jeremiahInnerBloodCD -= Time.deltaTime;

					if (jeremiahInnerBloodCD <= 0f) {
						jeremiahInnerBloodCooling = false;
						jeremiahInnerBloodCD = jeremiahInnerBloodSpeed;
					}
				}

				if (Device.Action1.WasPressed) {
					if (innerBlood == false)
						innerBlood = true;
					else
						innerBlood = false;
					anim.Play ("Ability 1", -1, 0f);
				}
				#endregion

				#region *** JEREMIAH CRIMSON REACH ***
				if (jeremiahCrimsonReachCooling) {
					jeremiahCrimsonReachCD -= Time.deltaTime;

					if (jeremiahCrimsonReachCD <= 0f) {
						jeremiahCrimsonReachCooling = false;
						jeremiahCrimsonReachCD = jeremiahCrimsonReachSpeed;
					}
				}

				if ((Device.LeftBumper.WasPressed)) {
					if (jeremiahCrimsonReachCooling == false) {
						if (crimsonReachIndicator.activeSelf == false) {
							crimsonReachIndicator.SetActive (true);
						} else if (crimsonReachIndicator.activeSelf == true) {
							jeremiahCrimsonReach (jeremiahCrimsonReachRange);
							anim.Play ("Ability 2", -1, 0f);
							crimsonReachIndicator.SetActive (false);
						}
					}
				}
				#endregion

				// Moving and rotating the character with the left stick
				CharacterController Controller = GetComponent<CharacterController> ();

				if (jeremiahSlowed == false) {
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

				if (jeremiahSlowed == true) {
					moveDirection = new Vector3 (Device.LeftStickX, 0, Device.LeftStickY);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed - jeremiahSlowedAmount;

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

	public void jeremiahBasic (float jeremiahBasicRange)
	{
		jeremiahBasicCooling = true;
		Vector3 explosionPos = basicSpawnPoint.transform.position;
		Collider[] hitColliders = Physics.OverlapSphere (explosionPos, jeremiahBasicRange);

		foreach (Collider hit in hitColliders) {
			if ((hit.GetComponent<Collider> ().tag == "Player") && (hit.gameObject != playerParent.gameObject) && (Vector3.Angle (basicSpawnPoint.transform.forward, hit.transform.position - explosionPos) <= slimConeAngle)) {
				healthBarScript = hit.transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
				healthBarScript.GetHit (jeremiahBasicDamage);
			}
		}
	}

	public void jeremiahInnerBlood (float jeremiahInnerBloodRange)
	{
		jeremiahInnerBloodCooling = true;
		Vector3 explosionPos = basicSpawnPoint.transform.position;
		Collider[] hitColliders = Physics.OverlapSphere (explosionPos, jeremiahInnerBloodRange);

		foreach (Collider hit in hitColliders) {
			if ((hit.GetComponent<Collider> ().tag == "Player") && (hit.gameObject != playerParent.gameObject) && (Vector3.Angle (basicSpawnPoint.transform.forward, hit.transform.position - explosionPos) <= wideConeAngle)) {
				healthBarScript = hit.transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
				healthBarScript.GetHit (jeremiahInnerBloodDamage);
			}
		}
	}

	public void jeremiahCrimsonReach (float jeremiahCrimsonReachRange)
	{
		jeremiahCrimsonReachCooling = true;
		if (collisionTriggerScript.triggered == true) {
			for (int i = 0; i < collisionTriggerScript.targets.Count; i++) {
				if (collisionTriggerScript.targets[i].name == "Xander") {
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().canMove = false;
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().xanderSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<XanderScript> ().xanderSlowedLength += jeremiahCrimsonReachSlowLength;
					collisionTriggerScript.targets[i].transform.position = crimsonReachSpawnPoint.transform.position;
				}
				if (collisionTriggerScript.targets[i].name == "Shera") {
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().canMove = false;
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().sheraSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<SheraScript> ().sheraSlowedLength += jeremiahCrimsonReachSlowLength;
					collisionTriggerScript.targets[i].transform.position = crimsonReachSpawnPoint.transform.position;
				}
				if (collisionTriggerScript.targets[i].name == "Croak") {
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().canMove = false;
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().croakSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<CroakScript> ().croakSlowedLength += jeremiahCrimsonReachSlowLength;
					collisionTriggerScript.targets[i].transform.position = crimsonReachSpawnPoint.transform.position;
				}
				if (collisionTriggerScript.targets[i].name == "Jeremiah") {
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().canMove = false;
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().jeremiahSlowed = true;
					collisionTriggerScript.targets[i].transform.GetComponent<JeremiahScript> ().jeremiahSlowedLength += jeremiahCrimsonReachSlowLength;
					collisionTriggerScript.targets[i].transform.position = crimsonReachSpawnPoint.transform.position;
				}
			}
			collisionTriggerScript.targets.Clear();
		}
	}
}