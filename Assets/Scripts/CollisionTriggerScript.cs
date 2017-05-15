using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerScript : MonoBehaviour {

	public GameObject parent;
	public bool triggered;
	public List<GameObject> targets;

	void Start () {
		triggered = false;
	}

	void OnTriggerEnter (Collider col) {
		if ((col.gameObject != parent) && (col.tag == "Player")) {
			triggered = true;
			targets.Add (col.gameObject);
		} else {
			triggered = false;
		}
	}

	void OnTriggerExit (Collider col) {
		targets.Remove (col.gameObject);
		triggered = false;
	}
}