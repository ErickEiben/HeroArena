using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public Text roundCounter;

	public bool gameOver = false;

	DataManager dataManager;

	void Start () {
		dataManager = GameObject.Find ("DataManager").GetComponent<DataManager> ();
		roundCounter.text = ("Round: " + dataManager.roundNumber);
		dataManager.StartMainScene ();

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
	}

	void Update () {
		if (dataManager.player1Dead && dataManager.player2Dead) {
			dataManager.team2Wins++;
			ResetRound ();
		}
		if (dataManager.player3Dead && dataManager.player4Dead) {
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
		}
	}

	void ResetRound() {
		Destroy (dataManager.player1);
		Destroy (dataManager.player2);
		Destroy (dataManager.player3);
		Destroy (dataManager.player4);
		dataManager.StartMainScene ();
		dataManager.roundNumber++;
		roundCounter.text = ("Round: " + dataManager.roundNumber);
	}

}
