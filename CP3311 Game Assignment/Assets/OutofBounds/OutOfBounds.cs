using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	public Transform respawnPoint;
	Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void OnTriggerEnter(Collider other) {
		//Determine if the collider that entered the trigger is the player
		PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

		if (health != null)		{
			//Player takes damage
			health.TakeDamage(10);
			//move player back to respawn point
			player.position = respawnPoint.position;

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
