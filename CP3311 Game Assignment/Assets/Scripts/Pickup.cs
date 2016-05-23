using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{	
	public int points;
	public int pointsType;
	Transform move;
	float floatSpeed;
	float timer;
	GameObject scoreObject;
	ScoreManager scoreManager;

	void Start() {
		scoreObject = GameObject.FindGameObjectWithTag ("ScoreManager");
		scoreManager = scoreObject.GetComponent<ScoreManager> ();
		move = GetComponent<Transform> ();
		timer = 0;

		//how fast the pickups bob up and down
		floatSpeed = 0.1f;

		//set the pointsType so the score manager can tally the total score properly
		//	0  =  treasure
		//  1  =  killed enemy
		//  2  =  checkpoints or whatever?
		//  4  =  win

	}

	void FixedUpdate() {
		timer += Time.deltaTime;
		//bob up and down
		if (timer >= 0 && timer <= 2f) {
			move.Translate(Vector3.up * floatSpeed * Time.deltaTime);
		}
		if (timer > 2f && timer < 4f) {
			move.Translate (Vector3.down * floatSpeed * Time.deltaTime);
		} 
		if (timer > 4f) {
			timer = 0;
		}
			
		//rotate
		move.Rotate(Vector3.up, 1);
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Determine if the collider that entered the trigger is the player
		PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
		if (health != null)		{
			//Perform pickup
			scoreManager.AddScore(points, pointsType);
			
			//Destroy the pickup itself
			Destroy(gameObject);
		}
	}
}