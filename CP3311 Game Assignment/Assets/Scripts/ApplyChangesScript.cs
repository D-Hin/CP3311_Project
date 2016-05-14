using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class applyChangesScript : MonoBehaviour {

	//Game Objects
	public Toggle isEasy;
	public Toggle isHard;
	public Slider slider;
	public InputField inputField;

	public void ApplyPressed() {
		if (isEasy.isOn) {
			Debug.Log ("Player selected EASY difficulty");
		} else if (isHard.isOn) {
			Debug.Log ("Player selected HARD difficulty");
		}
	}

	public void OnSubmit() {
		ApplyPressed ();
	}
}