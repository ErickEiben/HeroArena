using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class PlayerSelectScript : MonoBehaviour
{
	public GameObject playerUIPrefab;
	public GameObject canvas;
	[HideInInspector] public GameObject playerJoin1;
	[HideInInspector] public GameObject playerJoin2;
	[HideInInspector] public GameObject playerJoin3;
	[HideInInspector] public GameObject playerJoin4;

	private Scene thisScene;

	const int maxPlayers = 4;

	List<Vector3> playerPositions = new List<Vector3> () {
		new Vector3 (-602, 175, 0),
		new Vector3 (-216, 175, 0),
		new Vector3 (174, 175, 0),
		new Vector3 (560, 175, 0),
	};

	List<SelectUIScript> players = new List<SelectUIScript> (maxPlayers);

	void Start ()
	{
		InputManager.OnDeviceDetached += OnDeviceDetached;

		thisScene = SceneManager.GetActiveScene ();

		playerJoin1 = GameObject.Find ("PlayerJoin1");
		playerJoin2 = GameObject.Find ("PlayerJoin2");
		playerJoin3 = GameObject.Find ("PlayerJoin3");
		playerJoin4 = GameObject.Find ("PlayerJoin4");
	}

	void Update ()
	{
		if (thisScene.name == "Scene_CharacterSelect") {
			var inputDevice = InputManager.ActiveDevice;

			if (JoinButtonWasPressedOnDevice (inputDevice)) {
				if (ThereIsNoPlayerUsingDevice (inputDevice)) {
					CreatePlayer (inputDevice);
				}
			}
		}
	}

	bool JoinButtonWasPressedOnDevice (InputDevice inputDevice)
	{
		return inputDevice.Action1.WasPressed || inputDevice.Action2.WasPressed || inputDevice.Action3.WasPressed || inputDevice.Action4.WasPressed;
	}

	SelectUIScript FindPlayerUsingDevice (InputDevice inputDevice)
	{
		var playerCount = players.Count;
		for (var i = 0; i < playerCount; i++) {
			var player = players [i];
			if (player.Device == inputDevice) {
				return player;
			}
		}

		return null;
	}

	bool ThereIsNoPlayerUsingDevice (InputDevice inputDevice)
	{
		return (FindPlayerUsingDevice (inputDevice) == null);
	}

	void OnDeviceDetached (InputDevice inputDevice)
	{
		var player = FindPlayerUsingDevice (inputDevice);
		if (player != null) {
			RemovePlayer (player);
		}
	}

	SelectUIScript CreatePlayer (InputDevice inputDevice)
	{
		if (players.Count < maxPlayers) {
			var playerPosition = playerPositions [0];
			playerPositions.RemoveAt (0);

			var gameObject = (GameObject)Instantiate (playerUIPrefab, Vector3.zero, Quaternion.identity);
			gameObject.transform.parent = canvas.transform;
			gameObject.transform.localPosition = playerPosition;
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
			var player = gameObject.GetComponent<SelectUIScript> ();
			player.Device = inputDevice;
			player.playerNumber = players.Count;
			players.Add (player);

			if (players.Count == 1) {
				playerJoin1.SetActive (false);
			} else if (players.Count == 2) {
				playerJoin2.SetActive (false);
			} else if (players.Count == 3) {
				playerJoin3.SetActive (false);
			} else if (players.Count == 4) {
				playerJoin4.SetActive (false);
			}

			return player;
		}
		return null;
	}

	void RemovePlayer (SelectUIScript player)
	{
		playerPositions.Insert (0, player.transform.position);
		players.Remove (player);
		player.Device = null;
		Destroy (player.gameObject);
	}

	void OnGUI ()
	{
		const float h = 22.0f;
		var y = 10.0f;

		GUI.color = Color.black;

		GUI.Label (new Rect (10, y, 300, y + h), "Active players: " + players.Count + "/" + maxPlayers);
		y += h;
	}
}