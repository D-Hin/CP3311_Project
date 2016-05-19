using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public Transform SpawnPoint;
	public GameObject PlayerController;			// apply this to the ThirdPersonController, NOT the player prefab

	void onTriggerEnter (Collider respawnCollider)
	{
		if (respawnCollider.tag == "Player") {
			PlayerController.transform.position = SpawnPoint.position;
		}
	}
}
