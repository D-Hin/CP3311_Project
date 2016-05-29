using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas optionsMenu;
	public Canvas creditsMenu;
	public Canvas quitMenu;
	public Toggle mouseUse;
	public Toggle backgroundMusic;
	public Slider slider;
	public InputField inputField;
	public GameObject gameManager;
	public AudioSource bgMusic;

	public string mouseMessage;
	public string musicMessage = "Yes";
	public float sliderValue;
	public string inputName;

	void Awake () {
		gameManager.SetActive (false);
		mainMenu.enabled = true;
		optionsMenu.enabled = false;
		creditsMenu.enabled = false;
		quitMenu.enabled = false;
	}
		
	public void Play() {
		gameManager.SetActive (true);
		if (mouseUse.isOn) {
			gameManager.GetComponent<GameMenu> ().SetFixedCam (true);
		} else {
			gameManager.GetComponent<GameMenu> ().SetFixedCam (false);
		}

		if (backgroundMusic.isOn) {
			gameManager.GetComponent<GameMenu> ().SetMusicOn (true);
		} else {
			gameManager.GetComponent<GameMenu> ().SetMusicOn (false);
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
		inputName = inputField.text;
	}

	public void OptionsToMain() {
		//Restore stored settings before modification...
		if (mouseMessage == "Yes") {
			mouseUse.isOn = true;
		} else if (mouseMessage == "No") {
			mouseUse.isOn = false;
		}

		if (musicMessage == "Yes") {
			gameManager.GetComponent<GameMenu> ().SetMusicOn (true);
		} else if (musicMessage == "No") {
			gameManager.GetComponent<GameMenu> ().SetMusicOn (false);
		}

		slider.value = sliderValue;
		inputField.text = inputName;

		optionsMenu.enabled = false;
		mainMenu.enabled = true;
	}
		
	public void ToCredits() {
		creditsMenu.enabled = true;
	}

	public void CreditsReturn() {
		creditsMenu.enabled = false;
	}

	public void ApplySettings() {
		if (mouseUse.isOn) {
			Debug.Log ("Player would like to use mouse");
			mouseMessage = "Yes";
			gameManager.GetComponent<GameMenu> ().SetFixedCam (true);
		} else {
			Debug.Log ("Player is not using the mouse");
			mouseMessage = "No";
			gameManager.GetComponent<GameMenu> ().SetFixedCam (false);
		}

		if (backgroundMusic.isOn) {
			Debug.Log ("Player has background music on");
			musicMessage = "Yes";
			bgMusic.mute = false;
		} else {
			Debug.Log ("Player is not playing background music");
			musicMessage = "No";
			bgMusic.mute = true;
		}
		sliderValue = slider.value;
		inputName = inputField.text;

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

//	public void musicToggle() {
//		if (backgroundMusic.isOn) {
//			bgMusic.mute = false;
//		} else {
//			bgMusic.mute = true;
//		}
//	}
}