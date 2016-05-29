using UnityEngine;
using System.Collections;

public class MessageSystem : MonoBehaviour 
{
	public string msg;
	GameMenu gameMenu;

	void OnTriggerEnter (Collider other)
	{	//check player touched checkpoint
		if (other.gameObject.tag == "Player") {
			//send attached message to hud
			gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
			gameMenu.SetMessage (msg);
		}
	}
}
