using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transition : MonoBehaviour {

	public int destination;

	void Start () {}

	void Update () {}

	void OnTriggerEnter(Collider other)	{
		//check if collider is the player
		PlayerHealth health = other.gameObject.GetComponentInParent<PlayerHealth>();
		if (health != null) {
			SceneManager.LoadScene (destination, LoadSceneMode.Single);			
		}
	}
}
