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
	public MusicCheck music;

	public menuScript menuScript;
	public InputField GMInputField;
	public Slider GMVolumeSlider;
	public Toggle GMMouseUse;
	public Toggle GMBackgroundMusic;

	private bool gameOver;
	private Color fadingBackground = new Color(0f, 0f, 0f, 0.1f);
	private float fadeSpeed = 0.1f;

	public int currentScene = 0;
	public int currentCheckpoint = 1;
	public bool fixedCam = true;
	public bool musicOn = true;
	public float musicVolume;

	public string playerName;

	float messageTimer = 0f;


	// Use this for initialization
	void Awake () {
		playerName = menuScript.inputField.text;
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

	void Update() {
		//open/close pause menu
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
			//Turn on/off FPS counter
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

			//Player has died game over
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

		//Reload scene moving player to latest checkpoint
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

	public float GetVolume() {
		return musicVolume;
	}

	public void SetVolume(float value) {
		musicVolume = value;
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
		if (musicOn) {
			GMBackgroundMusic.isOn = true;
		} 
		else {
			GMBackgroundMusic.isOn = false;
		}

		GMVolumeSlider.value = musicVolume;
		GMInputField.text = playerName;

		//if (menuScript.mouseUse.isOn) {
		//	menuScript.mouseMessage = "Yes";
		//	GMMouseUse.isOn = true;
		//} 
		//else {
		//menuScript.mouseMessage = "No";
		//GMMouseUse.isOn = false;
		//}

		//if (menuScript.backgroundMusic.isOn) {
		//menuScript.musicMessage = "Yes";
		//GMBackgroundMusic.isOn = true;
		//} 
		//else {
		//menuScript.musicMessage = "No";
		//GMBackgroundMusic.isOn = false;
		//}
		//GMVolumeSlider.value = menuScript.sliderValue;
		//GMInputField.text = menuScript.inputField.text;
		//GMVolumeSlider.value = VolSliderValue;
		//}
	}

	public void VolumeAdjust() {
		GameObject.Find ("EthanMain").GetComponent<MusicCheck> ().ChangeVolume (GMVolumeSlider.normalizedValue);
	}

	public void GMOptionsToPause() {
		GMOptionsMenu.enabled = false;
		pauseMenu.enabled = true;
	}

	public void ApplySettings() {
		//Apply the changes to the menuScript options menu which will transfer changes to GM Options upon next opening

		if (GMBackgroundMusic.isOn == true) {
			GameObject.Find ("EthanMain").GetComponent<MusicCheck> ().TurnMusicOn(false);
			musicOn = true;
		} else {
			GameObject.Find ("EthanMain").GetComponent<MusicCheck> ().TurnMusicOn(true);
			musicOn = false;
		}

		musicVolume = GMVolumeSlider.value; 
		playerName = GMInputField.text;

		GMOptionsMenu.enabled = false;
		pauseMenu.enabled = true;

		//if (GMMouseUse.isOn == true) {
			//Debug.Log ("Player would like to use mouse");
			//menuScript.mouseMessage = "Yes";
			//menuScript.mouseUse.isOn = true;
			//SetFixedCam (false);
			//print (GetFixedCam());
		//} else {
			//Debug.Log ("Player is not using the mouse");
			//menuScript.mouseMessage = "No";
			//menuScript.mouseUse.isOn = false;
			//SetFixedCam (true);
			//print (GetFixedCam());
		//}

		//if (GMBackgroundMusic.isOn == true) {
			//Debug.Log ("Player has background music on");
			//menuScript.musicMessage = "Yes";
			//menuScript.backgroundMusic.isOn = true;
			//SetMusicOn (true);
			//print (GetMusicOn());
		//} else {
			//Debug.Log ("Player is not playing background music");
			//menuScript.musicMessage = "No";
			//menuScript.backgroundMusic.isOn = false;
			//SetMusicOn (false);
			//print (GetMusicOn());
		//}
		//menuScript.inputField.text = GMInputField.text;
		//menuScript.sliderValue = GMVolumeSlider.value; 
		//VolSliderValue = GMVolumeSlider.value;
	}
}

