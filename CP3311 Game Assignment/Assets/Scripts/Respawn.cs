﻿using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public Transform SpawnPoint;
	public GameObject Player;

	void onTriggerEnter (Collider respawnCollider)
	{
		if (respawnCollider.gameObject.tag == "Player") {
			Player.transform.position = SpawnPoint.position;
		}
	}
}
