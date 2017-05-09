using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	public static AnimationScript S;

	public Animator anim;
	public bool selected = false;

	void Awake ()
	{
		S = this;
	}

	void Start ()
	{
		anim = this.gameObject.GetComponent<Animator> ();
	}

	void Update ()
	{
		if ((selected == false) && (this.name == "XanderPlayerSelect")) {
			anim.Play ("Character Select Idle_Xander", 0, 0f);
		}
		if ((selected == false) && (this.name == "BloodhunterPlayerSelect")) {
			anim.Play ("Character Select Idle_Jeremiah2", 0, 0f);
		}
		if ((selected == false) && (this.name == "CroakPlayerSelect")) {
			anim.Play ("Character Select Idle_Croak", 0, 0f);
		}
		if ((selected == false) && (this.name == "SheraPlayerSelect")) {
			anim.Play ("Character Select Idle_Shera", 0, 0f);
		}


		if ((selected == true) && (this.name == "XanderPlayerSelect")) {
			anim.Play ("Character Selected Idle_Xander", 0, 0f);
		}
		if ((selected == true) && (this.name == "BloodhunterPlayerSelect")) {
			anim.Play ("Character Selected Idle_Jeremiah2", 0, 0f);
		}
		if ((selected == true) && (this.name == "CroakPlayerSelect")) {
			anim.Play ("Character Selected Idle_Croak", 0, 0f);
		}
		if ((selected == true) && (this.name == "SheraPlayerSelect")) {
			anim.Play ("Character Selected Idle_Shera", 0, 0f);
		}
	}

}
