using UnityEngine;
using System.Collections;

public class PlaySoundScript : MonoBehaviour {
	public AudioSource sceneBackgroundMusic;
	private AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {
		backgroundMusic = sceneBackgroundMusic.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		backgroundMusic.Play ();
	}
}
