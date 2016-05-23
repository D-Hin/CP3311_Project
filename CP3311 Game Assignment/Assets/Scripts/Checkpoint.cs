using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	public int checkPointNum;
	GameMenu gameMenu;

	void OnTriggerEnter (Collider checkPointCollider)
	{	//check player touched checkpoint
		if (checkPointCollider.gameObject.tag == "Player") {
			//set the players respawn point to this one
			gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
			gameMenu.SetCurrentCheckpoint (checkPointNum);
		}
	}
}
