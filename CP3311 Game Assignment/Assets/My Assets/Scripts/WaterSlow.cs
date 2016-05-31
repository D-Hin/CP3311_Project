using UnityEngine;
using System.Collections;

public class WaterSlow : MonoBehaviour {

	public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl player;
	// Use this for initialization

	void OnTriggerEnter(Collider other){
		//print ("player is in water");
		player.SetInWater (true);
	}

	void OnTriggerExit(Collider other) {
		//print("out of water");
		player.SetInWater (false);
	}
}

