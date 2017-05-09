using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	public static AnimationScript S;

	public Animator anim;
	SelectUIScript uiScript;

	void Awake ()
	{
		S = this;
	}

	void Start ()
	{
		anim = this.gameObject.GetComponent<Animator> ();
		uiScript = this.gameObject.GetComponentInParent<SelectUIScript> ();
	}

	void Update ()
	{
		if ((uiScript.canInteract == true) && (this.name == "XanderPlayerSelect")) {
			anim.Play ("Character Select Idle", -1, 0f);
		}
		if ((uiScript.canInteract == true) && (this.name == "BloodhunterPlayerSelect")) {
			anim.Play ("Character Select Idle", -1, 0f);
		}
		if ((uiScript.canInteract == true) && (this.name == "CroakPlayerSelect")) {
			anim.Play ("Character Select Idle", -1, 0f);
		}
		if ((uiScript.canInteract == true) && (this.name == "SheraPlayerSelect")) {
			anim.Play ("Character Select Idle", -1, 0f);
		}


		if ((uiScript.canInteract == false) && (this.name == "XanderPlayerSelect")) {
			anim.Play ("Character Selected Idle", -1, 0f);
		}
		if ((uiScript.canInteract == false) && (this.name == "BloodhunterPlayerSelect")) {
			anim.Play ("Character Selected Idle", -1, 0f);
		}
		if ((uiScript.canInteract == false) && (this.name == "CroakPlayerSelect")) {
			anim.Play ("Character Selected Idle", -1, 0f);
		}
		if ((uiScript.canInteract == false) && (this.name == "SheraPlayerSelect")) {
			anim.Play ("Character Selected Idle", -1, 0f);
		}
	}

}
