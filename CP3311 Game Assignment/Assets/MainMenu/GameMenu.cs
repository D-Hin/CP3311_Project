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

	private bool gameOver;
	private Color fadingBackground = new Color(0f, 0f, 0f, 0.1f);
	private float fadeSpeed = 0.1f;

	public int currentScene = 0;
	public int currentCheckpoint = 1;


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
}