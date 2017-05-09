using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	public static HealthBarScript S;
	
	// Private variables
	private GameObject thisParent;
	private float maxHealth;
	[SerializeField] private float curHealth;
	private float calcHealth;
	private Image healthBar;

	private Image healthBarRed;
	private Image healthBarBlue;

	// Other script variable access
	XanderScript xanderScript;
	SheraScript sheraScript;
	JeremiahScript jeremiahScript;
	CroakScript croakScript;

	void Start ()
	{
		S = this;
		thisParent = this.transform.root.gameObject;
		healthBarRed = this.transform.FindChild ("HealthBar_Red").GetComponent<Image> ();
		healthBarBlue = this.transform.FindChild ("HealthBar_Blue").GetComponent<Image> ();
		if (thisParent.name == "Xander") {
			xanderScript = thisParent.GetComponent<XanderScript> ();
			maxHealth = xanderScript.maxHealth;
			if (xanderScript.team == 0) {
				healthBar = healthBarRed;
				healthBarRed.enabled = true;
				healthBarBlue.enabled = false;
			} else if (xanderScript.team == 1) {
				healthBar = healthBarBlue;
				healthBarRed.enabled = false;
				healthBarBlue.enabled = true;
			}
		} else if (thisParent.name == "Shera") {
			sheraScript = thisParent.GetComponent<SheraScript> ();
			maxHealth = sheraScript.maxHealth;
			if (sheraScript.team == 0) {
				healthBar = healthBarRed;
				healthBarRed.enabled = true;
				healthBarBlue.enabled = false;
			} else if (sheraScript.team == 1) {
				healthBar = healthBarBlue;
				healthBarRed.enabled = false;
				healthBarBlue.enabled = true;
			}
		} else if (thisParent.name == "Jeremiah") {
			jeremiahScript = thisParent.GetComponent<JeremiahScript> ();
			maxHealth = jeremiahScript.maxHealth;
			if (jeremiahScript.team == 0) {
				healthBar = healthBarRed;
				healthBarRed.enabled = true;
				healthBarBlue.enabled = false;
			} else if (jeremiahScript.team == 1) {
				healthBar = healthBarBlue;
				healthBarRed.enabled = false;
				healthBarBlue.enabled = true;
			}
		} else if (thisParent.name == "Croak") {
			croakScript = thisParent.GetComponent<CroakScript> ();
			maxHealth = croakScript.maxHealth;
			if (croakScript.team == 0) {
				healthBar = healthBarRed;
				healthBarRed.enabled = true;
				healthBarBlue.enabled = false;
			} else if (croakScript.team == 1) {
				healthBar = healthBarBlue;
				healthBarRed.enabled = false;
				healthBarBlue.enabled = true;
			}
		} else {
			maxHealth = 100f;
		}
		curHealth = maxHealth;

		healthBar.transform.localScale = new Vector3 (Mathf.Clamp (maxHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	public void GetHit (float healthLost)
	{
		curHealth -= healthLost;

		calcHealth = curHealth / maxHealth;

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		healthBar.transform.localScale = new Vector3 (Mathf.Clamp (calcHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	void Update ()
	{
		if (curHealth <= 0f) {
			Destroy (thisParent);
		}
	}
}