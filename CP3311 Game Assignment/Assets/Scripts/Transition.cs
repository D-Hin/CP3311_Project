using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transition : MonoBehaviour
{
	public int destination;

	void OnTriggerEnter (Collider transitionCollider)
	{
		//check if collider is the player
//		PlayerHealth health = transitionCollider.gameObject.GetComponentInParent<PlayerHealth>();
//		if (health != null) {
		if (transitionCollider.gameObject.tag == "Player") {
			SceneManager.LoadScene (destination, LoadSceneMode.Single);
		}
	}
}
