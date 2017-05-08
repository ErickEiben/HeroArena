using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas controlMenu;
	//public Canvas characterMenu;
	public Button startText;
	public Button exitText;
	public Button controlText;
	public Button characterText;
	public Button creditText;
	public Button Menu;
	public Button Shera;
	public Button Xander;
	public Button Croak;
	public Button Jeremiah;
	public Canvas characters;
	public Button XSplash;
	public Button SSplash;
	public Button CSplash;
	public Button JSplash;
	public Button XLore;
	public Button SLore;
	public Button CLore;
	public Button JLore;
	public Button back;
	public GameObject SplashX;
	public GameObject SplashS;
	public GameObject SplashC;
	public GameObject SplashJ;
	public GameObject XPage;
	public GameObject SPage;
	public GameObject CPage;
	public GameObject JPage;
	//public GameObject characterBack;

	private bool buttonSelected;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		controlMenu = controlMenu.GetComponent<Canvas> ();
		//characterMenu = characterMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		characterText = characterText.GetComponent<Button> ();
		controlText = controlText.GetComponent<Button> ();
		creditText = creditText.GetComponent<Button> ();
		Menu = Menu.GetComponent<Button> ();
		Shera = Shera.GetComponent<Button> ();
		Xander = Xander.GetComponent<Button> ();
		Croak = Croak.GetComponent<Button> ();
		Jeremiah = Jeremiah.GetComponent<Button> ();
		characters = characters.GetComponent<Canvas> ();
//		XSplash = XSplash.GetComponent<Button> ();
		//SSplash = SSplash.GetComponent<Button> ();
		//CSplash = CSplash.GetComponent<Button> ();
		//JSplash = JSplash.GetComponent<Button> ();
		//XLore = XLore.GetComponent<Button> ();
		//SLore = SLore.GetComponent<Button> ();
		//CLore = CLore.GetComponent<Button> ();
		//JLore = JLore.GetComponent<Button> ();
		back = back.GetComponent<Button> ();
		SplashX = SplashX.GetComponent<GameObject> ();
		SplashS = SplashS.GetComponent<GameObject> ();
		SplashC = SplashC.GetComponent<GameObject> ();
		SplashJ = SplashJ.GetComponent<GameObject> ();
		XPage = XPage.GetComponent<GameObject> ();
		SPage = SPage.GetComponent<GameObject> ();
		CPage = CPage.GetComponent<GameObject> ();
		JPage = JPage.GetComponent<GameObject> ();
		//characterBack = characterBack.GetComponent<GameObject> ();
		quitMenu.enabled = false;
		//characters.enabled = false;
		controlMenu.enabled = false;

	}

	// Update is called once per frame
	public void ExitPress () {
		quitMenu.enabled = true;
		startText.enabled = false;
		characterText.enabled = false;
		controlText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		controlText.enabled = true;
		characterText.enabled = true;
	}

	public void ControlPress(){
		startText.enabled = false;
		exitText.enabled = false;
		controlText.enabled = false;
		characterText.enabled = false;
		controlMenu.enabled = true;
	}

	public void CharacterPress(){
		startText.enabled = false;
		exitText.enabled = false;
		controlText.enabled = false;
		characterText.enabled = false;
		characters.enabled = true;
		//characterBack.SetActive (true);
		Xander.enabled = true;
		Shera.enabled = true;
		Croak.enabled = true;
		Jeremiah.enabled = true;
		back.enabled = true;
	}

	public void panelSwapping(GameObject panel){
		panel.SetActive (!panel.activeSelf);
	
	}
	/*
	public void XanderPress(){
		Xander.enabled = false;
		Shera.enabled = false;
		Croak.enabled = false;
		Jeremiah.enabled = false;
		//XPage.SetActive (true);
		//XLore.enabled = true;
		XSplash.enabled = true;
		back.enabled = true;
		//characterBack.SetActive (false);
		SplashX.SetActive (false);
	
	}

	public void SheraPress(){
		Xander.enabled = false;
		Shera.enabled = false;
		Croak.enabled = false;
		Jeremiah.enabled = false;
		//SPage.SetActive (true);
		//SLore.enabled = true;
		SSplash.enabled = true;
		back.enabled = true;
		//characterBack.SetActive(false);
		//SplashS.SetActive (false);

	}

	public void CroakPress(){
		Xander.enabled = false;
		Shera.enabled = false;
		Croak.enabled = false;
		Jeremiah.enabled = false;
		//CPage.SetActive (true);
		//CLore.enabled = true;
		CSplash.enabled = true;
		back.enabled = true;
		//characterBack.SetActive(false);
		//SplashC.SetActive (false);

	}

	public void JeremiahPress(){
		Xander.enabled = false;
		Shera.enabled = false;
		Croak.enabled = false;
		Jeremiah.enabled = false;
		//JPage.SetActive (true);
		//JLore.enabled = true;
		JSplash.enabled = true;
		back.enabled = true;
		//characterBack.SetActive(false);
		SplashJ.SetActive (false);

	}
	*/

	public void XSplashPress(){
		if (SplashX.active) {
			SplashX.SetActive (false);
		
		} else {
			SplashX.SetActive (true);
		}
	
	}

	public void SSplashPress(){
		if (SplashS.active) {
			SplashS.SetActive (false);

		} else {
			SplashS.SetActive (true);
		}

	}

	public void CSplashPress(){
		if (SplashC.active) {
			SplashC.SetActive (false);

		} else {
			SplashC.SetActive (true);
		}

	}

	public void JSplashPress(){
		if (SplashJ.active) {
			SplashJ.SetActive (false);

		} else {
			SplashJ.SetActive (true);
		}

	}
	/*
	public void charBack(){
		XPage.SetActive (false);
		SPage.SetActive (false);
		CPage.SetActive (false);
		JPage.SetActive (false);
		Xander.enabled = true;
		Shera.enabled = true;
		Croak.enabled = true;
		Jeremiah.enabled = true;
		//characterBack.SetActive(true);
		Menu.enabled = true;
	
	}

	public void BackPress(){
		startText.enabled = true;
		exitText.enabled = true;
		controlText.enabled = true;
		characterText.enabled = true;
		controlMenu.enabled = false;
		characters.enabled = false;
	}
*/
	public void StartLevel(){
		SceneManager.LoadScene ("Scene_CharacterSelect");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
