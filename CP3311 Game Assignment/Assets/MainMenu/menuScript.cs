using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas optionsMenu;
	public Canvas quitMenu;
	public Toggle mouseUse;
	public Toggle backgroundMusic;
	public Slider slider;
	public InputField inputField;
	public GameObject gameManager;

	public string mouseMessage;
	public string musicMessage;
	public float sliderValue;
	public string inputName;

	void Awake () {
		gameManager.SetActive (false);
		mainMenu.enabled = true;
		optionsMenu.enabled = false;
		quitMenu.enabled = false;
	}
		
	public void Play() {
		gameManager.SetActive (true);
		if (mouseUse.isOn) {
			gameManager.GetComponent<GameMenu> ().SetFixedCam (true);
		} else {
			gameManager.GetComponent<GameMenu> ().SetFixedCam (false);
		}
		SceneManager.LoadScene (1);

	}

	public void OptionsMenu() {
		mainMenu.enabled = false;
		optionsMenu.enabled = true;

		//Save options into variables to be reloaded in case cancel is selected...
		if (mouseUse.isOn) {
			mouseMessage = "Yes";
		} 
		else {
			mouseMessage = "No";
		}

		if (backgroundMusic.isOn) {
			musicMessage = "Yes";
		} 
		else {
			musicMessage = "No";
		}

		sliderValue = slider.value;
		//Debug.Log (sliderValue);
		inputName = inputField.text;
		//Debug.Log (inputName);
	}

	public void OptionsToMain() {
		//Restore stored settings before modification...
		if (mouseMessage == "Yes") {
			mouseUse.isOn = true;
		} else if (mouseMessage == "No") {
			mouseUse.isOn = false;
		}

		if (musicMessage == "Yes") {
			backgroundMusic.isOn = true;
		} else if (musicMessage == "No") {
			backgroundMusic.isOn = false;
		}

		slider.value = sliderValue;
		inputField.text = inputName;

		optionsMenu.enabled = false;
		mainMenu.enabled = true;
	}
		
	public void ApplySettings() {
		if (mouseUse.isOn) {
			Debug.Log ("Player would like to use mouse");
			mouseMessage = "Yes";
		} else {
			Debug.Log ("Player is not using the mouse");
			mouseMessage = "No";
		}

		if (backgroundMusic.isOn) {
			Debug.Log ("Player has background music on");
			musicMessage = "Yes";
		} else {
			Debug.Log ("Player is not playing background music");
			musicMessage = "No";
		}
		sliderValue = slider.value;
		//Debug.Log (sliderValue);
		inputName = inputField.text;
		//Debug.Log(inputName);

//		message = "settings : \nslider set to : " + slider.value + " \ntoggle 1 is ";
//		if (toggle1.isOn) {
//			message += "On \n";
//		} else {
//			message += "Off \n";
//		}
//		message += "toggle 2 is ";
//		if (toggle2.isOn) {
//			message += "On \n";
//		} else {
//			message += "Off \n";
//		}
//		message += "username is : " + inputField.text + " \n ";
//	
//		print (message);

		optionsMenu.enabled = false;
		mainMenu.enabled = true;
	}

	public void QuitMenu() {
		quitMenu.enabled = true;
	}

	public void QuitYes() {
		Application.Quit ();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void QuitNo() {
		quitMenu.enabled = false;
		mainMenu.enabled = true;
	}
}

//	public void SetSlider() {
//		sliderValue = slider.value;
//	}