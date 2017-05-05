using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class SelectUIScript : MonoBehaviour
{
	public static SelectUIScript S;

	[HideInInspector] public GameObject xanderPlayerSelect;
	[HideInInspector] public GameObject bloodhunterPlayerSelect;
	[HideInInspector] public GameObject croakPlayerSelect;
	[HideInInspector] public GameObject sheraPlayerSelect;
	[HideInInspector] public Image informationBox;
	[HideInInspector] public GameObject xanderInformation;
	[HideInInspector] public GameObject bloodhunterInformation;
	[HideInInspector] public GameObject croakInformation;
	[HideInInspector] public GameObject sheraInformation;

	public InputDevice Device { get; set; }

	void Awake ()
	{
		S = this;
	}

	void Start ()
	{
		#region *** FINDING GAMEOBJECTS ***
		xanderPlayerSelect = this.transform.FindChild ("XanderPlayerSelect").gameObject;
		bloodhunterPlayerSelect = this.transform.FindChild ("BloodhunterPlayerSelect").gameObject;
		croakPlayerSelect = this.transform.FindChild ("CroakPlayerSelect").gameObject;
		sheraPlayerSelect = this.transform.FindChild ("SheraPlayerSelect").gameObject;
		informationBox = this.transform.FindChild ("InformationBox").GetComponent<Image> ();

		xanderInformation = this.transform.FindChild ("XanderInformation").gameObject;
		bloodhunterInformation = this.transform.FindChild ("BloodhunterInformation").gameObject;
		croakInformation = this.transform.FindChild ("CroakInformation").gameObject;
		sheraInformation = this.transform.FindChild ("SheraInformation").gameObject;

		xanderPlayerSelect.SetActive (true);
		bloodhunterPlayerSelect.SetActive (false);
		croakPlayerSelect.SetActive (false);
		sheraPlayerSelect.SetActive (false);
		informationBox.enabled = true;

		this.name = "PlayerSelectUI";
		#endregion
	}

	void Update ()
	{
		if (Device != null) {
			#region *** RIGHT BUMPER ***
			if (Device.RightBumper.WasPressed) {
				if (xanderPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (true);
					bloodhunterInformation.SetActive (true);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
				else if (bloodhunterPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (true);
					croakInformation.SetActive (true);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
				else if (croakPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (true);
					sheraInformation.SetActive (true);
				}
				else if (sheraPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (true);
					xanderInformation.SetActive (true);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
			}
			#endregion

			#region *** LEFT BUMPER ***
			if (Device.LeftBumper.WasPressed) {
				if (xanderPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (true);
					sheraInformation.SetActive (true);
				}
				else if (bloodhunterPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (true);
					croakInformation.SetActive (true);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
				else if (croakPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					xanderInformation.SetActive (false);

					bloodhunterPlayerSelect.SetActive (true);
					bloodhunterInformation.SetActive (true);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
				else if (sheraPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (true);
					xanderInformation.SetActive (true);

					bloodhunterPlayerSelect.SetActive (false);
					bloodhunterInformation.SetActive (false);

					croakPlayerSelect.SetActive (false);
					croakInformation.SetActive (false);

					sheraPlayerSelect.SetActive (false);
					sheraInformation.SetActive (false);
				}
			}
			#endregion
		}
	}
}
