using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScriptExample : MonoBehaviour {

	public Canvas settingsMenu;
	public Canvas quitMenu;
	public Button startText;
	public Button settingsText;
	public Button exitText;

	//Game Objects
	public Toggle isEasy;
	public Toggle isHard;
	public Slider slider;
	public InputField inputField;

	private string difficulty;
	private float sliderValue;
	private string inputName;

	void Start () {
		settingsMenu = settingsMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		settingsMenu.enabled = false;
		quitMenu.enabled = false;
	}
		
	public void StartLevel() {
		SceneManager.LoadScene (1);
	}

	public void SettingsPress() {
		settingsMenu.enabled = true;
		quitMenu.enabled = false;
		startText.enabled = false;
		settingsText.enabled = false;
		exitText.enabled = false;

		//Save options into variables to be reloaded in case cancel is selected...
		if (isEasy.isOn) {
			difficulty = "Easy";
			//Debug.Log (difficulty);
		} 
		else if (isHard.isOn) {
			difficulty = "Hard";
			//Debug.Log (difficulty);
		}
		sliderValue = slider.value;
		//Debug.Log (sliderValue);
		inputName = inputField.text;
		//Debug.Log (inputName);
	}
		
	public void ExitPress() {
		quitMenu.enabled = true;
		startText.enabled = false;
		settingsText.enabled = false;
		exitText.enabled = false;
		settingsMenu.enabled = false;
	}

	public void NoPress() {
		quitMenu.enabled = false;
		startText.enabled = true;
		settingsText.enabled = true;
		exitText.enabled = true;
		settingsMenu.enabled = false;
	}

	public void CancelPress() {
		quitMenu.enabled = false;
		startText.enabled = true;
		settingsText.enabled = true;
		exitText.enabled = true;
		settingsMenu.enabled = false;

		//Restore stored settings before modification...
		if (difficulty == "Easy") {
			isEasy.isOn = true;
		} else if (difficulty == "Hard") {
			isHard.isOn = true;
		}
		slider.value = sliderValue;
		inputField.text = inputName;
	}

	public void ExitGame() {
		Application.Quit();
	}
		
	//Save toggle, slider & input field information and display to the console...
	public void ApplyPressed() {
		if (isEasy.isOn) {
			Debug.Log ("Player selected EASY difficulty");
		} else if (isHard.isOn) {
			Debug.Log ("Player selected HARD difficulty");
		}
		sliderValue = slider.value;
		Debug.Log (sliderValue);
		inputName = inputField.text;
		Debug.Log(inputName);

		settingsMenu.enabled = false;
		startText.enabled = true;
		settingsText.enabled = true;
		exitText.enabled = true;
	}
}