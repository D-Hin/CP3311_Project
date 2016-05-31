using UnityEngine;
using System.Collections;

public class MenuChalice : MonoBehaviour
{	
	Transform move;
	float floatSpeed;
	float rotateSpeed;
	float timer;

	void Start() {
		move = GetComponent<Transform> ();
		timer = 0;

		//how fast it bobs up and down
		floatSpeed = 0.04f;
		rotateSpeed = 0.2f;

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
		move.Rotate(Vector3.up, rotateSpeed);
	}

}