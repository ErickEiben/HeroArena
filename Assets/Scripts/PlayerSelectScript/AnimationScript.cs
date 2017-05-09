using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

	[HideInInspector] public Animator anim;
	[HideInInspector] public bool selected = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if ((selected == false) && (this.name == "XanderPlayerSelect")) {
			anim.Play ("Character Select Idle_Xander");
		}
		if ((selected == false) && (this.name == "BloodhunterPlayerSelect")) {
			anim.Play ("Character Select Idle_Jeremiah");
		}
		if ((selected == false) && (this.name == "CroakPlayerSelect")) {
			anim.Play ("Character Select Idle_Croak");
		}
		if ((selected == false) && (this.name == "SheraPlayerSelect")) {
			anim.Play ("Character Select Idle_Shera");
		}
	}

}
