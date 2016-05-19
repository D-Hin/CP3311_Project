#pragma strict

var SpawnPoint: Transform;

var PlayerController: GameObject;			// apply this to the ThirdPersonController, NOT the player prefab

function OnTriggerEnter(respawnCollider: Collider)
{
	if(respawnCollider.tag == "Player")
	{
		PlayerController.transform.position = SpawnPoint.position;
	}
}