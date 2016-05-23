using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
	Transform player;
	GameMenu gameMenu;
	int checkpointNum;
	string pointName;
	Transform spawnPoint;

	void Start ()
	{
		player = GetComponent<Transform> ();		// first time player enters scene it positions player
		Respawn ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			Respawn ();								// allows the player to respawn without pausing
		}
	}

	public void Respawn ()
	{
		//check what the players latest checkpoint is
		gameMenu = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameMenu> ();
		checkpointNum = gameMenu.GetCurrentCheckpoint ();
		//find that checkpoint in the scene
		pointName = "Checkpoint" + checkpointNum;
		spawnPoint = GameObject.FindGameObjectWithTag (pointName).GetComponent<Transform> ();
		//move player to spawnpoint
		player.position = spawnPoint.position;
	}
}
