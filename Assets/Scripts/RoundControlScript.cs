using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundControlScript : MonoBehaviour {

	public SpriteRenderer round1_team1_empty;
	public SpriteRenderer round2_team1_empty;
	public SpriteRenderer round3_team1_empty;
	public SpriteRenderer round1_team1_filled;
	public SpriteRenderer round2_team1_filled;
	public SpriteRenderer round3_team1_filled;

	public SpriteRenderer round1_team2_empty;
	public SpriteRenderer round2_team2_empty;
	public SpriteRenderer round3_team2_empty;
	public SpriteRenderer round1_team2_filled;
	public SpriteRenderer round2_team2_filled;
	public SpriteRenderer round3_team2_filled;

	[HideInInspector] public float gameOverCD;
	[HideInInspector] public float gameOverWaitTime;
	[HideInInspector] public bool gameOver = false;

	public Text roundCounter;
	public Text team1Victory;
	public Text team2Victory;

	DataManager dataManager;

	void Start () {
		dataManager = GameObject.Find ("DataManager").GetComponent<DataManager> ();
		roundCounter.text = ("Round: " + dataManager.roundNumber);
		dataManager.StartMainScene ();
		gameOverWaitTime = 5f;
		gameOverCD = 5f;

		round1_team1_empty.enabled = true;
		round2_team1_empty.enabled = true;
		round3_team1_empty.enabled = true;
		round1_team1_filled.enabled = false;
		round2_team1_filled.enabled = false;
		round3_team1_filled.enabled = false;
		round1_team2_empty.enabled = true;
		round2_team2_empty.enabled = true;
		round3_team2_empty.enabled = true;
		round1_team2_filled.enabled = false;
		round2_team2_filled.enabled = false;
		round3_team2_filled.enabled = false;

		team1Victory.enabled = false;
		team2Victory.enabled = false;
	}
	void Update () {

		if (gameOver) {
			gameOverCD -= Time.deltaTime;

			if (gameOverCD <= 0f) {
				gameOverCD = gameOverWaitTime;
				if (gameOver == true) {
					dataManager.RemoveDontDestroyOnLoads ();
					SceneManager.LoadScene ("Scene_Menu");
				}
			}

		} else {
			if ((dataManager.player1Dead) && (dataManager.player2Dead)) {
				dataManager.team2Wins++;
				ResetRound ();
			}
			if ((dataManager.player3Dead) && (dataManager.player4Dead)) {
				dataManager.team1Wins++;
				ResetRound ();
			}

			if (dataManager.team1Wins == 1) {
				round1_team1_empty.enabled = false;
				round1_team1_filled.enabled = true;
			} else if (dataManager.team1Wins == 2) {
				round2_team1_empty.enabled = false;
				round2_team1_filled.enabled = true;
			} else if (dataManager.team1Wins == 3) {
				round3_team1_empty.enabled = false;
				round3_team1_filled.enabled = true;
				gameOver = true;
				team1Victory.enabled = true;
			}

			if (dataManager.team2Wins == 1) {
				round1_team2_empty.enabled = false;
				round1_team2_filled.enabled = true;
			} else if (dataManager.team2Wins == 2) {
				round2_team2_empty.enabled = false;
				round2_team2_filled.enabled = true;
			} else if (dataManager.team2Wins == 3) {
				round3_team2_empty.enabled = false;
				round3_team2_filled.enabled = true;
				gameOver = true;
				team2Victory.enabled = true;
			}
		}
	}

	void ResetRound() {
		GameObject[] players;
		players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			Destroy (player);
		}
		dataManager.player1Dead = false;
		dataManager.player2Dead = false;
		dataManager.player3Dead = false;
		dataManager.player4Dead = false;
		dataManager.StartMainScene ();
		dataManager.roundNumber++;
		roundCounter.text = ("Round: " + dataManager.roundNumber);
	}
}
