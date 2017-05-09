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

	public int player1character;
	public int player2character;
	public int player3character;
	public int player4character;

	public int player1TeamColor;
	public int player2TeamColor;
	public int player3TeamColor;
	public int player4TeamColor;

	public int player1Team = 0;
	public int player2Team = 0;
	public int player3Team = 1;
	public int player4Team = 1;

	public InputDevice player1Device;
	public InputDevice player2Device;
	public InputDevice player3Device;
	public InputDevice player4Device;

	public Vector3 player1Position = new Vector3 (-7, 9, 1);
	public Vector3 player2Position = new Vector3 (-7, 9, -2);
	public Vector3 player3Position = new Vector3 (8, 9, 1);
	public Vector3 player4Position = new Vector3 (8, 9, -2);

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

		if (thisScene.name == "Scene_Main") {
			StartMainScene ();
			Destroy (this);
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
			} else if (player1character == 1) {
				var p1GameObject = (GameObject)Instantiate (bloodhunterPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<JeremiahScript> ();
				p1.team = 0;
				p1.Device = player1Device;
			} else if (player1character == 2) {
				var p1GameObject = (GameObject)Instantiate (croakPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<CroakScript> ();
				p1.team = 0;
				p1.Device = player1Device;
			} else if (player1character == 3) {
				var p1GameObject = (GameObject)Instantiate (sheraPrefab, player1Position, Quaternion.identity);
				var p1 = p1GameObject.GetComponent<SheraScript> ();
				p1.team = 0;
				p1.Device = player1Device;
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
			} else if (player2character == 1) {
				var p2GameObject = (GameObject)Instantiate (bloodhunterPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<JeremiahScript> ();
				p2.team = 0;
				p2.Device = player2Device;
			} else if (player2character == 2) {
				var p2GameObject = (GameObject)Instantiate (croakPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<CroakScript> ();
				p2.team = 0;
				p2.Device = player2Device;
			} else if (player2character == 3) {
				var p2GameObject = (GameObject)Instantiate (sheraPrefab, player2Position, Quaternion.identity);
				var p2 = p2GameObject.GetComponent<SheraScript> ();
				p2.team = 0;
				p2.Device = player2Device;
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
			} else if (player3character == 1) {
				var p3GameObject = (GameObject)Instantiate (bloodhunterPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<JeremiahScript> ();
				p3.team = 1;
				p3.Device = player3Device;
			} else if (player3character == 2) {
				var p3GameObject = (GameObject)Instantiate (croakPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<CroakScript> ();
				p3.team = 1;
				p3.Device = player3Device;
			} else if (player3character == 3) {
				var p3GameObject = (GameObject)Instantiate (sheraPrefab, player3Position, Quaternion.identity);
				var p3 = p3GameObject.GetComponent<SheraScript> ();
				p3.team = 1;
				p3.Device = player3Device;
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
			} else if (player4character == 1) {
				var p4GameObject = (GameObject)Instantiate (bloodhunterPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<JeremiahScript> ();
				p4.team = 1;
				p4.Device = player4Device;
			} else if (player4character == 2) {
				var p4GameObject = (GameObject)Instantiate (croakPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<CroakScript> ();
				p4.team = 1;
				p4.Device = player4Device;
			} else if (player4character == 3) {
				var p4GameObject = (GameObject)Instantiate (sheraPrefab, player4Position, Quaternion.identity);
				var p4 = p4GameObject.GetComponent<SheraScript> ();
				p4.team = 1;
				p4.Device = player4Device;
			}
		}
		#endregion
	}
}