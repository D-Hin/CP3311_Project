using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public Canvas GMOptionsMenu;
	public Canvas quitMenu;
	public Canvas gameOverCanvas;
	public Image gameOverBackground;
	public Text fpsCounter;
	public Slider healthSlider;
	public ScoreManager scoreManager;
	public Image messageBox;
	public Text messageText;
	public Text goalText;

	public menuScript menuScript;
	public InputField GMInputField;
	public Slider GMVolumeSlider;
	public Toggle mouseUse;
	public Toggle backgroundMusic;

	private bool gameOver;
	private Color fadingBackground = new Color(0f, 0f, 0f, 0.1f);
	private float fadeSpeed = 0.1f;

	public int currentScene = 0;
	public int currentCheckpoint = 1;
	public bool fixedCam = true;
	public bool musicOn = true;

	public AudioSource MainSceneAudio;
	public AudioSource JungleSceneAudio;
	public AudioSource VolcanoRoomsSceneAudio;
	public AudioSource EruptionSceneAudio;

	float messageTimer = 0f;


	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
		GMOptionsMenu.enabled = false;
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
			if ((Input.GetKeyDown (KeyCode.Escape) & GMOptionsMenu.enabled == false) || (Input.GetKeyDown (KeyCode.P) & GMOptionsMenu.enabled == false)) {
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

	public void PauseMenuToGMOptionsMenu() {
		pauseMenu.enabled = false;
		GMOptionsMenu.enabled = true;

		//Shows the same information on this option menu as does the initial option menu
		if (menuScript.mouseUse.isOn) {
			menuScript.mouseMessage = "Yes";
			mouseUse.isOn = true;
		} 
		else {
			menuScript.mouseMessage = "No";
			mouseUse.isOn = false;
		}

		if (menuScript.backgroundMusic.isOn) {
			menuScript.musicMessage = "Yes";
			backgroundMusic.isOn = true;
		} 
		else {
			menuScript.musicMessage = "No";
			backgroundMusic.isOn = false;
		}
		GMVolumeSlider.value = menuScript.sliderValue;
		GMInputField.text = menuScript.inputField.text;
	}

	public void GMOptionsToPause() {
		GMOptionsMenu.enabled = false;
		pauseMenu.enabled = true;
	}

	public void ApplySettings() {
		//Apply the changes to the menuScript options menu which will transfer changes to GM Options upon next opening
		if (mouseUse.isOn == true) {
			Debug.Log ("Player would like to use mouse");
			menuScript.mouseMessage = "Yes";
			menuScript.mouseUse.isOn = true;
			//SetFixedCam (false);
		} else {
			Debug.Log ("Player is not using the mouse");
			menuScript.mouseMessage = "No";
			menuScript.mouseUse.isOn = false;
			//SetFixedCam (true);
		}

		if (backgroundMusic.isOn == true) {
			Debug.Log ("Player has background music on");
			menuScript.musicMessage = "Yes";
			menuScript.backgroundMusic.isOn = true;
			//SetMusicOn (true);


		} else {
			Debug.Log ("Player is not playing background music");
			menuScript.musicMessage = "No";
			menuScript.backgroundMusic.isOn = false;
			//SetMusicOn (false);
		}
		menuScript.inputField.text = GMInputField.text;
		menuScript.sliderValue = GMVolumeSlider.value; 

		GMOptionsMenu.enabled = false;
		pauseMenu.enabled = true;
	}
}

