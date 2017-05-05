using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerSelectScript : MonoBehaviour
{
	public GameObject playerUIPrefab;
	public GameObject Canvas;

	const int maxPlayers = 4;

	List<Vector3> playerPositions = new List<Vector3> () {
		new Vector3 (-602, 150, 0),
		new Vector3 (-216, 150, 0),
		new Vector3 (174, 150, 0),
		new Vector3 (560, 150, 0),
	};

	List<SelectUIScript> players = new List<SelectUIScript> (maxPlayers);

	void Start ()
	{
		InputManager.OnDeviceDetached += OnDeviceDetached;
	}

	void Update ()
	{
		var inputDevice = InputManager.ActiveDevice;

		if (JoinButtonWasPressedOnDevice (inputDevice)) {
			if (ThereIsNoPlayerUsingDevice (inputDevice)) {
				CreatePlayer (inputDevice);
			}
		}
	}

	bool JoinButtonWasPressedOnDevice (InputDevice inputDevice)
	{
		return inputDevice.Action1.WasPressed || inputDevice.Action2.WasPressed || inputDevice.Action3.WasPressed || inputDevice.Action4.WasPressed;
		print ("Button Pressed");
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
			gameObject.transform.parent = Canvas.transform;
			gameObject.transform.position = new Vector3 ((Canvas.transform.position.x - playerPosition.x), (Canvas.transform.position.y + playerPosition.y), Canvas.transform.position.z);
			gameObject.transform.localScale = new Vector3 (2, 2, 2);
			var player = gameObject.GetComponent<SelectUIScript> ();
			player.Device = inputDevice;
			players.Add (player);

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

		if (players.Count < maxPlayers) {
			GUI.Label (new Rect (10, y, 300, y + h), "Press a button to join!");
			y += h;
		}
	}
}