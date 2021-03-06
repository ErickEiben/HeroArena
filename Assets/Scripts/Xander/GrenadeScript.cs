﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{

	HealthBarScript healthBarScript;
	private float lifeTime = 3f;
	private Rigidbody rb;
	public GameObject parent;
	[Range (0, 100)] public float thrust = 50f;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * thrust);
	}

	void Update ()
	{
		lifeTime -= Time.deltaTime;

		if (lifeTime <= 0f) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject != parent) {
			Explosion (col);
			Destroy (this.gameObject);
		}
	}

	void Explosion (Collision col)
	{
		if (col.gameObject.tag == "Player") {
			healthBarScript = col.transform.FindChild ("HealthBarCanvas").GetComponent<HealthBarScript> ();
			healthBarScript.GetHit (XanderScript.S.xanderBasicDamage);
		}
	}
}