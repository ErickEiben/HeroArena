using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class SelectUIScript : MonoBehaviour
{
	public static SelectUIScript S;

	#region *** Variables ***

	[HideInInspector] public GameObject xanderPlayerSelect;
	[HideInInspector] public GameObject bloodhunterPlayerSelect;
	[HideInInspector] public GameObject croakPlayerSelect;
	[HideInInspector] public GameObject sheraPlayerSelect;
	[HideInInspector] public GameObject xanderInformation;
	[HideInInspector] public GameObject bloodhunterInformation;
	[HideInInspector] public GameObject croakInformation;
	[HideInInspector] public GameObject sheraInformation;

	[HideInInspector] public Image team1Information;
	[HideInInspector] public Image team2Information;
	[HideInInspector] public Image team3Information;
	[HideInInspector] public Image team4Information;
	[HideInInspector] public Image team5Information;
	[HideInInspector] public Image team6Information;

	[HideInInspector] [Range (0, 3)] public int characterSelected;
	[HideInInspector] [Range (0, 5)] public int teamColor;
	[HideInInspector] [Range (0, 3)] public int playerNumber;

	private bool canInteract;

	#endregion

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

		xanderInformation = this.transform.FindChild ("XanderInformation").gameObject;
		bloodhunterInformation = this.transform.FindChild ("BloodhunterInformation").gameObject;
		croakInformation = this.transform.FindChild ("CroakInformation").gameObject;
		sheraInformation = this.transform.FindChild ("SheraInformation").gameObject;

		team1Information = this.transform.FindChild ("Team1Information").GetComponent<Image> ();
		team2Information = this.transform.FindChild ("Team2Information").GetComponent<Image> ();
		team3Information = this.transform.FindChild ("Team3Information").GetComponent<Image> ();
		team4Information = this.transform.FindChild ("Team4Information").GetComponent<Image> ();
		team5Information = this.transform.FindChild ("Team5Information").GetComponent<Image> ();
		team6Information = this.transform.FindChild ("Team6Information").GetComponent<Image> ();

		xanderPlayerSelect.SetActive (true);
		bloodhunterPlayerSelect.SetActive (false);
		croakPlayerSelect.SetActive (false);
		sheraPlayerSelect.SetActive (false);

		this.name = "PlayerSelectUI";
		canInteract = true;
		#endregion
	}

	void Update ()
	{
		if (Device != null) {
			if (canInteract == true) {
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
					} else if (bloodhunterPlayerSelect.activeSelf == true) {
						xanderPlayerSelect.SetActive (false);
						xanderInformation.SetActive (false);

						bloodhunterPlayerSelect.SetActive (false);
						bloodhunterInformation.SetActive (false);

						croakPlayerSelect.SetActive (true);
						croakInformation.SetActive (true);

						sheraPlayerSelect.SetActive (false);
						sheraInformation.SetActive (false);
					} else if (croakPlayerSelect.activeSelf == true) {
						xanderPlayerSelect.SetActive (false);
						xanderInformation.SetActive (false);

						bloodhunterPlayerSelect.SetActive (false);
						bloodhunterInformation.SetActive (false);

						croakPlayerSelect.SetActive (false);
						croakInformation.SetActive (false);

						sheraPlayerSelect.SetActive (true);
						sheraInformation.SetActive (true);
					} else if (sheraPlayerSelect.activeSelf == true) {
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
					} else if (bloodhunterPlayerSelect.activeSelf == true) {
						xanderPlayerSelect.SetActive (false);
						xanderInformation.SetActive (false);

						bloodhunterPlayerSelect.SetActive (false);
						bloodhunterInformation.SetActive (false);

						croakPlayerSelect.SetActive (true);
						croakInformation.SetActive (true);

						sheraPlayerSelect.SetActive (false);
						sheraInformation.SetActive (false);
					} else if (croakPlayerSelect.activeSelf == true) {
						xanderPlayerSelect.SetActive (false);
						xanderInformation.SetActive (false);

						bloodhunterPlayerSelect.SetActive (true);
						bloodhunterInformation.SetActive (true);

						croakPlayerSelect.SetActive (false);
						croakInformation.SetActive (false);

						sheraPlayerSelect.SetActive (false);
						sheraInformation.SetActive (false);
					} else if (sheraPlayerSelect.activeSelf == true) {
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

				#region *** CHANGE TEAM COLOR ***
				if (Device.Action3.WasPressed) {
					if (team1Information.enabled == true) {
						team1Information.enabled = false;
						team2Information.enabled = true;
						team3Information.enabled = false;
						team4Information.enabled = false;
						team5Information.enabled = false;
						team6Information.enabled = false;
					} else if (team2Information.enabled == true) {
						team1Information.enabled = false;
						team2Information.enabled = false;
						team3Information.enabled = true;
						team4Information.enabled = false;
						team5Information.enabled = false;
						team6Information.enabled = false;
					} else if (team3Information.enabled == true) {
						team1Information.enabled = false;
						team2Information.enabled = false;
						team3Information.enabled = false;
						team4Information.enabled = true;
						team5Information.enabled = false;
						team6Information.enabled = false;
					} else if (team4Information.enabled == true) {
						team1Information.enabled = false;
						team2Information.enabled = false;
						team3Information.enabled = false;
						team4Information.enabled = false;
						team5Information.enabled = true;
						team6Information.enabled = false;
					} else if (team5Information.enabled == true) {
						team1Information.enabled = false;
						team2Information.enabled = false;
						team3Information.enabled = false;
						team4Information.enabled = false;
						team5Information.enabled = false;
						team6Information.enabled = true;
					} else if (team6Information.enabled == true) {
						team1Information.enabled = true;
						team2Information.enabled = false;
						team3Information.enabled = false;
						team4Information.enabled = false;
						team5Information.enabled = false;
						team6Information.enabled = false;
					}
				}
				#endregion

				if (Device.Action1.WasPressed) {
					SelectCharacter ();
					canInteract = false;
				}
			}
		}
	}

	public void SelectCharacter ()
	{
		if (xanderPlayerSelect.activeSelf) {
			characterSelected = 0;
		} else if (bloodhunterPlayerSelect.activeSelf) {
			characterSelected = 1;
		} else if (croakPlayerSelect.activeSelf) {
			characterSelected = 2;
		} else if (sheraPlayerSelect.activeSelf) {
			characterSelected = 3;
		}

		if (team1Information.enabled == true) {
			teamColor = 0;
		} else if (team2Information.enabled == true) {
			teamColor = 1;
		} else if (team3Information.enabled == true) {
			teamColor = 2;
		} else if (team4Information.enabled == true) {
			teamColor = 3;
		} else if (team5Information.enabled == true) {
			teamColor = 4;
		} else if (team6Information.enabled == true) {
			teamColor = 5;
		}

		if (playerNumber == 0) {
			DataManager.S.player1Device = this.Device;
			DataManager.S.player1character = this.characterSelected;
			DataManager.S.player1Team = this.teamColor;
		} else if (playerNumber == 1) {
			DataManager.S.player2Device = this.Device;
			DataManager.S.player2character = this.characterSelected;
			DataManager.S.player2Team = this.teamColor;
		} else if (playerNumber == 2) {
			DataManager.S.player3Device = this.Device;
			DataManager.S.player3character = this.characterSelected;
			DataManager.S.player3Team = this.teamColor;
		} else if (playerNumber == 3) {
			DataManager.S.player4Device = this.Device;
			DataManager.S.player4character = this.characterSelected;
			DataManager.S.player4Team = this.teamColor;
		}
	}
}