using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public int checkPointNum;
	GameMenu gameMenu;

	void Start() {
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu>();
	}

	void OnTriggerEnter (Collider other)
	{	//check player touched checkpoint
		if (other.gameObject.tag == "Player") {
			gameMenu.SetCurrentCheckpoint (checkPointNum);
		}
	}
}
