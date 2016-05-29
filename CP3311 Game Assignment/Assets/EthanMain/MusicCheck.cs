using UnityEngine;
using System.Collections;

public class MusicCheck : MonoBehaviour {
	GameMenu gameMenu;
	public AudioSource bgMusic;
	// Use this for initialization
	void Start () {
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
		if (!gameMenu.GetMusicOn ()) {
			bgMusic.mute = true;
		} else {
			bgMusic.mute = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
