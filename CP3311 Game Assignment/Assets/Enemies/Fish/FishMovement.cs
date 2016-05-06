using UnityEngine;
using System.Collections;

//vastly modified from initial example code from http://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html

public class FishMovement : MonoBehaviour {

	public Transform start;
	public Transform jump1;
	public Transform jump2;
	public Transform end;
	public float speed;
	public float jumpHeight = 3f;
	public float jumpHeightDropOffRate = 0.04f;
	public float jumpSpeedBoost = 2f;

	Vector3 target;
	float jumpSpeed;
	bool reverse;

	void Start(){
		target = jump1.position;
		jumpSpeed = 0f;
		reverse = false;
	}

	void FixedUpdate() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		transform.Translate (Vector3.up * jumpSpeed * Time.deltaTime);
		if (jumpSpeed > 0) {
			jumpSpeed -= jumpHeightDropOffRate;
		}
		//right to left pass
		if (!reverse) {
			if (target == jump2.position) {
				//corrects for position error jumpSpeed causes
				if (Vector3.Distance (transform.position, target) < 0.1) {
					transform.position = jump2.position;
				}
			}
			//speed up for jump
			if (transform.position == jump1.position) {
				target = jump2.position;
				speed += jumpSpeedBoost;
				jumpSpeed = jumpHeight;
			}
			//slow down after jump
			if (transform.position == jump2.position) {
				target = end.position;
				speed -= jumpSpeedBoost;
				jumpSpeed = 0f;
			}
			if (transform.position == end.position) {
				reverse = true;
				//rotate fish and swim back
				transform.Rotate(new Vector3(0, 180, 0));
				target = jump2.position;
			}
		}
		//left to right pass
		if (reverse) {
			if (target == jump1.position) {
				//corrects for position error jumpSpeed causes
				if (Vector3.Distance (transform.position, target) < 0.1) {
					transform.position = jump1.position;
				}
			}
			//speed up for jump
			if (transform.position == jump2.position) {
				target = jump1.position;
				speed += jumpSpeedBoost;
				jumpSpeed = jumpHeight;
			}
			//slow down after jump
			if (transform.position == jump1.position) {
				target = start.position;
				speed -= jumpSpeedBoost;
				jumpSpeed = 0f;
			}
			if (transform.position == start.position) {
				reverse = false;
				//rotate fish and swim back
				transform.Rotate(new Vector3(0, -180, 0));
				target = jump1.position;
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		//hurt the player if he touches the fishy
		PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
		if (health != null)		{
			health.TakeDamage (10);
		}
	}

}