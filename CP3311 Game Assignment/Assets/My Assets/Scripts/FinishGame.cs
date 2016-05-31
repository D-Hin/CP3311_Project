using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {

	GameObject gameManager;
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
	public Text congratulationsText;
	bool finished = false;
	float moveSpeed = 1f;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu>();
		boatMesh.enabled = false;
		ethanMesh.enabled = false;
		chalice.enabled = false;
		finishCam.enabled = false;
		finishCam.GetComponent<AudioListener> ().enabled = false;
		finishCam.GetComponent<AudioSource> ().enabled = false;
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
			if (gameMenu.GetMusicOn ()) {
				finishCam.GetComponent<AudioListener> ().enabled = true;
				finishCam.GetComponent<AudioSource> ().enabled = true;
			}
			//Destroy (gameMenu);
			finishCam.enabled = true;
			boatMesh.enabled = true;
			ethanMesh.enabled = true;
			chalice.enabled = true;
			finished = true;
			finishCanvas.enabled = true;
			scoreText.text = "Your final score is " + finalScore + "!";
			congratulationsText.text = "Congratulations " + gameMenu.playerName + "!";
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void finishGameBtn () {
		DestroyObject (gameManager);
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
		//Application.Quit ();
		//#if UNITY_EDITOR
		//UnityEditor.EditorApplication.isPlaying = false;
		//#endif
	}
}
