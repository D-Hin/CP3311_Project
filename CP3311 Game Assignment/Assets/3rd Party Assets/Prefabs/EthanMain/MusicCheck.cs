using UnityEngine;
using System.Collections;

public class MusicCheck : MonoBehaviour {
	GameMenu gameMenu;
	public AudioSource bgMusic;
	float bgVolume;
	// Use this for initialization
	void Start () {
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
		if (gameMenu.GetMusicOn ()) {
			bgMusic.mute = false;
		} else {
			bgMusic.mute = true;
		}
		bgVolume = gameMenu.GetVolume ();
		bgMusic.volume = bgVolume;
	}
	
	public void TurnMusicOn(bool value){
		bgMusic.mute = value;
	}

	public void ChangeVolume(float value){
		bgMusic.volume = value;
	}
}
