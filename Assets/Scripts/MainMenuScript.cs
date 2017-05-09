using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayButton () {
		SceneManager.LoadScene ("Scene_CharacterSelect");
	}

	public void QuitButtion () {
		Application.Quit ();
	}

}
