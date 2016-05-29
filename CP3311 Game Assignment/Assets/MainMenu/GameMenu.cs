using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public Canvas quitMenu;
	public Canvas gameOverCanvas;
	public Image gameOverBackground;
	public Text fpsCounter;
	public Slider healthSlider;
	public ScoreManager scoreManager;
	public Image messageBox;
	public Text messageText;
	public Text goalText;

	private bool gameOver;
	private Color fadingBackground = new Color(0f, 0f, 0f, 0.1f);
	private float fadeSpeed = 0.1f;

	public int currentScene = 0;
	public int currentCheckpoint = 1;
	public bool fixedCam = true;
	public bool musicOn = true;

	float messageTimer = 0f;


	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
		pauseMenu.enabled = false;
		quitMenu.enabled = false;
		gameOverCanvas.enabled = false;
		fpsCounter.enabled = false;
	}

	void Start () {
		gameOver = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}

	void Update()
	{	//open/close pause menu
		messageTimer += Time.deltaTime;
		DoMessage ();
		if (!gameOver) {
			if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
				pauseMenu.enabled = !pauseMenu.enabled;
				Time.timeScale = Time.timeScale == 0 ? 1 : 0;
				if (Cursor.lockState == CursorLockMode.None) {
					Cursor.lockState = CursorLockMode.Locked;
				} else {
					Cursor.lockState = CursorLockMode.None;
				}
				Cursor.visible = !Cursor.visible;
			}
			//turn on/off FPS counter
			if (Input.GetKeyDown (KeyCode.F)) {
				fpsCounter.enabled = !fpsCounter.enabled;
			}

			if (Input.GetKeyDown (KeyCode.Alpha0)) {
				SceneManager.LoadScene (0);
			}
			//Island Beginning
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				SceneManager.LoadScene (1);
			}
			//Jungle Beginning
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				SceneManager.LoadScene (2);
			}
			//Island Volcano
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				currentCheckpoint = 4;
				SceneManager.LoadScene (1);
			}
			//Treasure Room Beginging
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				currentCheckpoint = 1;
				SceneManager.LoadScene (3);
			}
			//Item Room Beginning
			if (Input.GetKeyDown (KeyCode.Alpha5)) {
				currentCheckpoint = 2;
				SceneManager.LoadScene (3);
			}
			//Eruption Beginning
			if (Input.GetKeyDown (KeyCode.Alpha6)) {
				SceneManager.LoadScene (4);
			}

			//player has died game over
			if (healthSlider.value <= 0) {
				gameOver = true;
				gameOverCanvas.enabled = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}


		} 
		if (gameOver) {
			gameOverBackground.color = fadingBackground;
			fadeSpeed += 0.04f;
			fadingBackground = new Color (0f, 0f, 0f, fadeSpeed);
		}
	}


	public void Resume() {
		pauseMenu.enabled = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
	}

	public void Quit() {
		quitMenu.enabled = true;
	}

	public void QuitYes() {
		DestroyObject (transform.gameObject);
		SceneManager.LoadScene (0);
		Time.timeScale = 1;

	}

	public void QuitNo() {
		quitMenu.enabled = false;
	}

	public void GameOverTryAgain() {
		healthSlider.value = healthSlider.maxValue;
		gameOver = false;
		gameOverBackground.color = Color.clear;
		fadeSpeed = 0.1f;
		gameOverCanvas.enabled = false;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		scoreManager.SubScore (-1000);

		//reload scene moving player to latest checkpoint
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene (5);

	}

	public void LoadCheckpoint() {
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerRespawn> ().Respawn ();
	}

	public int GetCurrentScene() {
			return currentScene;
	}
	public void SetCurrentScene(int value) {
		currentScene = value;
	}

	public int GetCurrentCheckpoint() {
		return currentCheckpoint;
	}
	public void SetCurrentCheckpoint(int value) {
		currentCheckpoint = value;
	}

	public bool GetFixedCam() {
		return fixedCam;
	}
	public void SetFixedCam(bool value) {
		fixedCam = value;
	}

	public bool GetMusicOn() {
		return musicOn;
	}
	public void SetMusicOn(bool value) {
		musicOn = value;
	}

	void DoMessage() {
		if (messageTimer < 6f) {
			messageBox.color = new Color (0.5f, 0.5f, 0.5f, 0.3f);
			messageText.color = Color.white;
		} else {
			messageBox.color = Color.clear;
			messageText.color = Color.clear;
		}
	}

	public void SetMessage(string msg){
		messageText.text = msg;
		messageTimer = 0f;
	}
	public void SetGoalMessage(string goal) {
		goalText.text = goal;
	}

}