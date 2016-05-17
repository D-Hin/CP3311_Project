using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public Transform SpawnPoint;

	void onTriggerEnter (Collider checkpointCollider)
	{
		if (checkpointCollider.tag == "Player") {
//		if (checkpointCollider.gameObject.tag == "Player") {
			SpawnPoint.position = transform.position;
//			SpawnPoint.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
