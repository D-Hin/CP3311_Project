using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
	MeshRenderer mesh;

	float timer;
	bool isActive;

	void Start () {
		isActive = true;
		mesh = GetComponent<MeshRenderer> ();
	}

	void Update () {
		if (isActive != true) {
			timer += Time.deltaTime;
			if (timer > 5f) {
				isActive = true;
				mesh.enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (isActive) {
			//Determine if the collider that entered the trigger is the player
			PlayerHealth health = other.gameObject.GetComponent<PlayerHealth> ();
			if (health != null) {
				//Heal the player
				health.TakeDamage (-20);
			
				//Destroy the pickup itself
				timer = 0;
				mesh.enabled = false;
				isActive = false;
			}
		}
	}
}
