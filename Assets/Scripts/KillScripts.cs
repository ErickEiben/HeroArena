using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScripts : MonoBehaviour {

	void Update () {
		GameObject kill = GameObject.Find ("DataManager");
		Destroy (kill);
		GameObject kill2 = GameObject.Find ("PlayerManager");
		Destroy (kill2);
	}

}
