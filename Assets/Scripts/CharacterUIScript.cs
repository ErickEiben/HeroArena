using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class CharacterUIScript : MonoBehaviour {

	public SpriteRenderer bluePortait;
	public SpriteRenderer redPortait;
	public SpriteRenderer greenPortait;
	public SpriteRenderer yellowPortait;
	public SpriteRenderer purplePortait;
	public SpriteRenderer orangePortait;

	public SpriteRenderer croak_A1;
	public SpriteRenderer croak_A2;
	public SpriteRenderer jeremiah_A1;
	public SpriteRenderer jeremiah_A2;
	public SpriteRenderer shera_A1;
	public SpriteRenderer shera_A2;
	public SpriteRenderer xander_A1;
	public SpriteRenderer xander_A2;

	public SpriteRenderer croak_Headshot;
	public SpriteRenderer jeremiah_Headshot;
	public SpriteRenderer shera_Headshot;
	public SpriteRenderer xander_Headshot;

	DataManager dataManager;

	void Start () {

		/*
		bluePortait = this.transform.FindChild ("BluePortait").GetComponent<SpriteRenderer> ();
		redPortait = this.transform.FindChild ("RedPortait").GetComponent<SpriteRenderer> ();
		greenPortait = this.transform.FindChild ("GreenPortait").GetComponent<SpriteRenderer> ();
		yellowPortait = this.transform.FindChild ("YellowPortait").GetComponent<SpriteRenderer> ();
		purplePortait = this.transform.FindChild ("PurplePortait").GetComponent<SpriteRenderer> ();
		orangePortait = this.transform.FindChild ("OrangePortait").GetComponent<SpriteRenderer> ();
		*/

		croak_A1 = this.transform.FindChild ("Croak_A1").GetComponent<SpriteRenderer> ();
		croak_A2 = this.transform.FindChild ("Croak_A2").GetComponent<SpriteRenderer> ();
		jeremiah_A1 = this.transform.FindChild ("Jeremiah_A1").GetComponent<SpriteRenderer> ();
		jeremiah_A2 = this.transform.FindChild ("Jeremiah_A2").GetComponent<SpriteRenderer> ();
		shera_A1 = this.transform.FindChild ("Shera_A1").GetComponent<SpriteRenderer> ();
		shera_A2 = this.transform.FindChild ("Shera_A2").GetComponent<SpriteRenderer> ();
		xander_A1 = this.transform.FindChild ("Xander_A1").GetComponent<SpriteRenderer> ();
		xander_A2 = this.transform.FindChild ("Xander_A2").GetComponent<SpriteRenderer> ();

		croak_Headshot = this.transform.FindChild ("Croak_Headshot").GetComponent<SpriteRenderer> ();
		jeremiah_Headshot = this.transform.FindChild ("Jeremiah_Headshot").GetComponent<SpriteRenderer> ();
		shera_Headshot = this.transform.FindChild ("Shera_Headshot").GetComponent<SpriteRenderer> ();
		xander_Headshot = this.transform.FindChild ("Xander_Headshot").GetComponent<SpriteRenderer> ();

		dataManager = GameObject.Find ("DataManager").GetComponent<DataManager> ();

		if (this.name == "Player1_UI") {
			if (dataManager.player1Device != null) {
				if (dataManager.player1TeamColor == 0) {
					bluePortait.enabled = true;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player1TeamColor == 1) {
					bluePortait.enabled = false;
					redPortait.enabled = true;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player1TeamColor == 2) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = true;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player1TeamColor == 3) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = true;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player1TeamColor == 4) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = true;
					orangePortait.enabled = false;
				} else if (dataManager.player1TeamColor == 5) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = true;
				}

				if (dataManager.player1character == 0) {
					xander_Headshot.enabled = true;
					xander_A1.enabled = true;
					xander_A2.enabled = true;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player1character == 1) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = true;
					jeremiah_A1.enabled = true;
					jeremiah_A2.enabled = true;
				} else if (dataManager.player1character == 2) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = true;
					croak_A1.enabled = true;
					croak_A2.enabled = true;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player1character == 3) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = true;
					shera_A1.enabled = true;
					shera_Headshot.enabled = true;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				}
			}
		} else if (this.name == "Player2_UI") {
			if (dataManager.player2Device != null) {
				if (dataManager.player2TeamColor == 0) {
					bluePortait.enabled = true;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player2TeamColor == 1) {
					bluePortait.enabled = false;
					redPortait.enabled = true;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player2TeamColor == 2) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = true;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player2TeamColor == 3) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = true;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player2TeamColor == 4) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = true;
					orangePortait.enabled = false;
				} else if (dataManager.player2TeamColor == 5) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = true;
				}

				if (dataManager.player2character == 0) {
					xander_Headshot.enabled = true;
					xander_A1.enabled = true;
					xander_A2.enabled = true;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player2character == 1) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = true;
					jeremiah_A1.enabled = true;
					jeremiah_A2.enabled = true;
				} else if (dataManager.player2character == 2) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = true;
					croak_A1.enabled = true;
					croak_A2.enabled = true;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player2character == 3) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = true;
					shera_A1.enabled = true;
					shera_Headshot.enabled = true;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				}
			}

		} else if (this.name == "Player3_UI") {
			if (dataManager.player3Device != null) {
				if (dataManager.player3TeamColor == 0) {
					bluePortait.enabled = true;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player3TeamColor == 1) {
					bluePortait.enabled = false;
					redPortait.enabled = true;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player3TeamColor == 2) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = true;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player3TeamColor == 3) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = true;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player3TeamColor == 4) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = true;
					orangePortait.enabled = false;
				} else if (dataManager.player3TeamColor == 5) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = true;
				}

				if (dataManager.player3character == 0) {
					xander_Headshot.enabled = true;
					xander_A1.enabled = true;
					xander_A2.enabled = true;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player3character == 1) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = true;
					jeremiah_A1.enabled = true;
					jeremiah_A2.enabled = true;
				} else if (dataManager.player3character == 2) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = true;
					croak_A1.enabled = true;
					croak_A2.enabled = true;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player3character == 3) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = true;
					shera_A1.enabled = true;
					shera_Headshot.enabled = true;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				}
			}

		} else if (this.name == "Player4_UI") {
			if (dataManager.player4Device != null) {
				if (dataManager.player4TeamColor == 0) {
					bluePortait.enabled = true;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player4TeamColor == 1) {
					bluePortait.enabled = false;
					redPortait.enabled = true;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player4TeamColor == 2) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = true;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player4TeamColor == 3) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = true;
					purplePortait.enabled = false;
					orangePortait.enabled = false;
				} else if (dataManager.player4TeamColor == 4) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = true;
					orangePortait.enabled = false;
				} else if (dataManager.player4TeamColor == 5) {
					bluePortait.enabled = false;
					redPortait.enabled = false;
					greenPortait.enabled = false;
					yellowPortait.enabled = false;
					purplePortait.enabled = false;
					orangePortait.enabled = true;
				}

				if (dataManager.player4character == 0) {
					xander_Headshot.enabled = true;
					xander_A1.enabled = true;
					xander_A2.enabled = true;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player4character == 1) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = true;
					jeremiah_A1.enabled = true;
					jeremiah_A2.enabled = true;
				} else if (dataManager.player4character == 2) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = true;
					croak_A1.enabled = true;
					croak_A2.enabled = true;
					shera_Headshot.enabled = false;
					shera_A1.enabled = false;
					shera_Headshot.enabled = false;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				} else if (dataManager.player4character == 3) {
					xander_Headshot.enabled = false;
					xander_A1.enabled = false;
					xander_A2.enabled = false;
					croak_Headshot.enabled = false;
					croak_A1.enabled = false;
					croak_A2.enabled = false;
					shera_Headshot.enabled = true;
					shera_A1.enabled = true;
					shera_Headshot.enabled = true;
					jeremiah_Headshot.enabled = false;
					jeremiah_A1.enabled = false;
					jeremiah_A2.enabled = false;
				}

			}
		}
	}
}
