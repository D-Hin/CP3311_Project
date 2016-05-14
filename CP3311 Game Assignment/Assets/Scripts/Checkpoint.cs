using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public Transform SpawnPoint;

	void onTriggerEnter (Collider respawnCollider)
	{
		if (respawnCollider.gameObject.tag == "Player") {
//			SpawnPoint.position = this.transform.position;

		/*	The following line is based off of a JS code (requires further adjustments)	*/
//			SpawnPoint.position = Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
