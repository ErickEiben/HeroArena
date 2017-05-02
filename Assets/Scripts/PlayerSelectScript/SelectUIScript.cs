using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class SelectUIScript : MonoBehaviour
{
	public static SelectUIScript S;

	public GameObject xanderPlayerSelect;
	public GameObject bloodhunterPlayerSelect;
	public GameObject croakPlayerSelect;
	public GameObject sheraPlayerSelect;
	public Image informationBox;

	public InputDevice Device { get; set; }

	void Awake ()
	{
		S = this;
	}

	void Start ()
	{
		xanderPlayerSelect = this.transform.FindChild ("XanderPlayerSelect").gameObject;
		bloodhunterPlayerSelect = this.transform.FindChild ("BloodhunterPlayerSelect").gameObject;
		croakPlayerSelect = this.transform.FindChild ("CroakPlayerSelect").gameObject;
		sheraPlayerSelect = this.transform.FindChild ("SheraPlayerSelect").gameObject;
		informationBox = this.transform.FindChild ("InformationBox").GetComponent<Image> ();

		xanderPlayerSelect.SetActive (true);
		bloodhunterPlayerSelect.SetActive (false);
		croakPlayerSelect.SetActive (false);
		sheraPlayerSelect.SetActive (false);
		informationBox.enabled = true;
	}

	void Update ()
	{
		if (Device != null) {
			if (Device.RightBumper.WasPressed) {
				if (xanderPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (true);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (false);
				}
				else if (bloodhunterPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (true);
					sheraPlayerSelect.SetActive (false);
				}
				else if (croakPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (true);
				}
				else if (sheraPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (true);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (false);
				}
			}

			if (Device.LeftBumper.WasPressed) {
				if (xanderPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (true);
				}
				else if (bloodhunterPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (true);
					sheraPlayerSelect.SetActive (false);
				}
				else if (croakPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (false);
					bloodhunterPlayerSelect.SetActive (true);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (false);
				}
				else if (sheraPlayerSelect.activeSelf == true) {
					xanderPlayerSelect.SetActive (true);
					bloodhunterPlayerSelect.SetActive (false);
					croakPlayerSelect.SetActive (false);
					sheraPlayerSelect.SetActive (false);
				}
			}
		}
	}
}
