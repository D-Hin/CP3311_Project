﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {

	GameMenu gameMenu;
	int finalScore;
	public GameObject player;
	public GameObject boat;
	public MeshRenderer boatMesh;
	public SkinnedMeshRenderer ethanMesh;
	public MeshRenderer chalice;
	public Transform finishBoat;
	public Camera finishCam;
	public Canvas finishCanvas;
	public Text scoreText;
	bool finished = false;
	float moveSpeed = 1f;

	void Start() {
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu>();
		boatMesh.enabled = false;
		ethanMesh.enabled = false;
		chalice.enabled = false;
		finishCam.enabled = false;
		finishCanvas.enabled = false;
	}

	void FixedUpdate() {
		if (finished) {
			finishBoat.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy (player);
			Destroy (boat);
			finalScore = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ().GetScore ();
			gameMenu.enabled = false;
			Destroy (gameMenu);
			finishCam.enabled = true;
			boatMesh.enabled = true;
			ethanMesh.enabled = true;
			chalice.enabled = true;
			finished = true;
			finishCanvas.enabled = true;
			scoreText.text = "Your final score is " + finalScore + "!";
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

		}
	}

	public void finishGameBtn () {
		DestroyObject (transform.gameObject);
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	}
}