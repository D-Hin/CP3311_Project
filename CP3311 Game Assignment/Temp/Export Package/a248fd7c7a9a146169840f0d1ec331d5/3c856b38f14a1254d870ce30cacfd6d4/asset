using UnityEngine;
using System.Collections;

public class MessageSystem : MonoBehaviour 
{
	public int messageNum;
	GameMenu gameMenu;

	void OnTriggerEnter (Collider other)
	{	//check player touched checkpoint
		if (other.gameObject.tag == "Player") {
			//set the players respawn point to this one
			gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
			gameMenu.SetMessage (messageNum);
		}
	}
}
