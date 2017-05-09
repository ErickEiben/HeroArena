using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
	public static DataManager S;

	#region *** VARIABLES ***

	public GameObject xanderPrefab;
	public GameObject bloodhunterPrefab;
	public GameObject croakPrefab;
	public GameObject sheraPrefab;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public int roundNumber;
	public int team1Wins;
	public int team2Wins;

	[HideInInspector] public bool player1Dead = false;
	[HideInInspector] public bool player2Dead = false;
	[HideInInspector] public bool player3Dead = false;
	[HideInInspector] public bool player4Dead = false;

	[HideInInspector] public int player1character;
	[HideInInspector] public int player2character;
	[HideInInspector] public int player3character;
	[HideInInspector] public int player4character;

	[HideInInspector] public int player1TeamColor;
	[HideInInspector] public int player2TeamColor;
	[HideInInspector] public int player3TeamColor;
	[HideInInspector] public int player4TeamColor;

	[HideInInspector] public int player1Team = 0;
	[HideInInspector] public int player2Team = 0;
	[HideInInspector] public int player3Team = 1;
	[HideInInspector] public int player4Team = 1;

	[HideInInspector] public InputDevice player1Device;
	[HideInInspector] public InputDevice player2Device;
	[HideInInspector] public InputDevice player3Device;
	[HideInInspector] public InputDevice player4Device;

	[HideInInspector] public Vector3 player1Position = new Vector3 (-7, 9, 1);
	[HideInInspector] public Vector3 player2Position = new Vector3 (-7, 9, -2);
	[HideInInspector] public Vector3 player3Position = new Vector3 (8, 9, 1);
	[HideInInspector] public Vector3 player4Position = new Vector3 (8, 9, -2);

	private Scene thisScene;

	#endregion

	void Start ()
	{
		DontDestroyOnLoad (this);
		S = this;
	}

	void Update ()
	{
		thisScene = SceneManager.GetActiveScene (); 
		if (thisScene.name == "Scene_CharacterSelect") {
			if (InputManager.ActiveDevice.CommandWasPressed) {
				SceneManager.LoadScene ("Scene_Main");
			}
		}
	}

	public void StartMainScene ()
	{
		#region *** Player 1 Creation ***
		if (player1Device != null) {
			if (player1character == 0) {
				var p1GameObject = (GameObject)Instantiate (xanderPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<XanderScript> ();
				p1.team = 0;
				p1.Device = player1Device;
				p1.playerPosition = 0;
				p1GameObject = player1;
			} else if (player1character == 1) {
				var p1GameObject = (GameObject)Instantiate (bloodhunterPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<JeremiahScript> ();
				p1.team = 0;
				p1.Device = player1Device;
				p1.playerPosition = 0;
				p1GameObject = player1;
			} else if (player1character == 2) {
				var p1GameObject = (GameObject)Instantiate (croakPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<CroakScript> ();
				p1.team = 0;
				p1.Device = player1Device;
				p1.playerPosition = 0;
				p1GameObject = player1;
			} else if (player1character == 3) {
				var p1GameObject = (GameObject)Instantiate (sheraPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<SheraScript> ();
				p1.team = 0;
				p1.Device = player1Device;
				p1.playerPosition = 0;
				p1GameObject = player1;
			}
		}
		#endregion

		#region *** Player 2 Creation ***
		if (player2Device != null) {
			if (player2character == 0) {
				var p2GameObject = (GameObject)Instantiate (xanderPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<XanderScript> ();
				p2.team = 0;
				p2.Device = player2Device;
				p2.playerPosition = 1;
				p2GameObject = player2;
			} else if (player2character == 1) {
				var p2GameObject = (GameObject)Instantiate (bloodhunterPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<JeremiahScript> ();
				p2.team = 0;
				p2.Device = player2Device;
				p2.playerPosition = 1;
				p2GameObject = player2;
			} else if (player2character == 2) {
				var p2GameObject = (GameObject)Instantiate (croakPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<CroakScript> ();
				p2.team = 0;
				p2.Device = player2Device;
				p2.playerPosition = 1;
				p2GameObject = player2;
			} else if (player2character == 3) {
				var p2GameObject = (GameObject)Instantiate (sheraPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<SheraScript> ();
				p2.team = 0;
				p2.Device = player2Device;
				p2.playerPosition = 1;
				p2GameObject = player2;
			}
		}
		#endregion

		#region *** Player 3 Creation ***
		if (player3Device != null) {
			if (player3character == 0) {
				var p3GameObject = (GameObject)Instantiate (xanderPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<XanderScript> ();
				p3.team = 1;
				p3.Device = player3Device;
				p3.playerPosition = 2;
				p3GameObject = player3;
			} else if (player3character == 1) {
				var p3GameObject = (GameObject)Instantiate (bloodhunterPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<JeremiahScript> ();
				p3.team = 1;
				p3.Device = player3Device;
				p3.playerPosition = 2;
				p3GameObject = player3;
			} else if (player3character == 2) {
				var p3GameObject = (GameObject)Instantiate (croakPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<CroakScript> ();
				p3.team = 1;
				p3.Device = player3Device;
				p3.playerPosition = 2;
				p3GameObject = player3;
			} else if (player3character == 3) {
				var p3GameObject = (GameObject)Instantiate (sheraPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<SheraScript> ();
				p3.team = 1;
				p3.Device = player3Device;
				p3.playerPosition = 2;
				p3GameObject = player3;
			}
		}
		#endregion

		#region *** Player 4 Creation ***
		if (player4Device != null) {
			if (player4character == 0) {
				var p4GameObject = (GameObject)Instantiate (xanderPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<XanderScript> ();
				p4.team = 1;
				p4.Device = player4Device;
				p4.playerPosition = 3;
				p4GameObject = player4;
			} else if (player4character == 1) {
				var p4GameObject = (GameObject)Instantiate (bloodhunterPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<JeremiahScript> ();
				p4.team = 1;
				p4.Device = player4Device;
				p4.playerPosition = 3;
				p4GameObject = player4;
			} else if (player4character == 2) {
				var p4GameObject = (GameObject)Instantiate (croakPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<CroakScript> ();
				p4.team = 1;
				p4.Device = player4Device;
				p4.playerPosition = 3;
				p4GameObject = player4;
			} else if (player4character == 3) {
				var p4GameObject = (GameObject)Instantiate (sheraPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<SheraScript> ();
				p4.team = 1;
				p4.Device = player4Device;
				p4.playerPosition = 3;
				p4GameObject = player4;
			}
		}
		#endregion
	}
}