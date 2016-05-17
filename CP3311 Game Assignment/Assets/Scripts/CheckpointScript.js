#pragma strict

var SpawnPoint: Transform;

function OnTriggerEnter(checkpointCollider: Collider)
{
	if(checkpointCollider.tag == "Player")
	{
		SpawnPoint.position = Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
}