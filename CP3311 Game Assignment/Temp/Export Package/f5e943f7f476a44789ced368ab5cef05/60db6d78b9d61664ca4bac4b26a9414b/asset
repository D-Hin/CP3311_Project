using UnityEngine;
using System.Collections;

public class MessageGoalSystem : MonoBehaviour 
{
	public string goalMsg;
	GameMenu gameMenu;

	void OnTriggerEnter (Collider other)
	{	//check player touched checkpoint
		if (other.gameObject.tag == "Player") {
			//send attached message to hud
			gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
			gameMenu.SetGoalMessage (goalMsg);
		}
	}
}
