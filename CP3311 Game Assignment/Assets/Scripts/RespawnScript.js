#pragma strict

var SpawnPoint: Transform;

var Player: GameObject;

function OnTriggerEnter(respawnCollider: Collider)
{
	if(respawnCollider.tag == "Player")
	{
		Player.transform.position = SpawnPoint.position;
	}
}