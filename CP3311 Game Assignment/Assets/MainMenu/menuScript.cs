﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas optionsMenu;
	public Canvas quitMenu;
	public Toggle toggle1;
	public Toggle toggle2;
	public Slider slider;
	public InputField inputField;
	public GameObject gameManager;

	private string message;
	//private float sliderValue;
	private string inputName;

	void Awake () {
		gameManager.SetActive (false);
		mainMenu.enabled = true;
		optionsMenu.enabled = false;
		quitMenu.enabled = false;
	}
		
	public void Play() {
		gameManager.SetActive (true);
		SceneManager.LoadScene (1);

	}

	public void OptionsMenu() {
		mainMenu.enabled = false;
		optionsMenu.enabled = true;
	}

	public void OptionsToMain() {
		optionsMenu.enabled = false;
		mainMenu.enabled = true;
	}

//	public void SetSlider() {
//		sliderValue = slider.value;
//	}

	public void ApplySettings() {
		message = "settings : \nslider set to : " + slider.value + " \ntoggle 1 is ";
		if (toggle1.isOn) {
			message += "On \n";
		} else {
			message += "Off \n";
		}
		message += "toggle 2 is ";
		if (toggle2.isOn) {
			message += "On \n";
		} else {
			message += "Off \n";
		}
		message += "username is : " + inputField.text + " \n ";
	
		print (message);
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