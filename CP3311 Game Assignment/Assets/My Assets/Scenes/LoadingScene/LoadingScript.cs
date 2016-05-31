using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {
	GameMenu gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
		SceneManager.LoadScene (gameManager.GetCurrentScene());
	}
}
