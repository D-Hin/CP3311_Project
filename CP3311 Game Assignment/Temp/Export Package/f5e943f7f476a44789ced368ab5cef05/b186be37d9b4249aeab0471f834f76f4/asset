using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transition : MonoBehaviour
{
	public int sceneTarget;
	public int checkpointTarget;
	GameMenu gameMenu;

	void OnTriggerEnter (Collider transitionCollider)
	{
		//check if collider is the player
//		PlayerHealth health = transitionCollider.gameObject.GetComponentInParent<PlayerHealth>();
//		if (health != null) {
		if (transitionCollider.gameObject.tag == "Player") {
			gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
			gameMenu.SetCurrentCheckpoint (checkpointTarget);
			SceneManager.LoadScene (sceneTarget, LoadSceneMode.Single);
		}
	}
}
