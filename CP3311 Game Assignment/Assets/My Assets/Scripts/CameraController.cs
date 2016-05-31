using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject firstPersonCamera;
	public GameObject thirdPersonCamera;
	
	public int activeCamera = 0;
	
	public GameObject charcterBody;

	void Start ()
	{
		firstPersonCamera.SetActive (false);
//		thirdPersonCamera.SetActive (true);
//		charcterBody.SetActive (true);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Camera")) {
			if (activeCamera == 0) {
				firstPersonCamera.SetActive (true);
				thirdPersonCamera.SetActive (false);
				charcterBody.SetActive (false);
				activeCamera = 1;
	
			} else if (activeCamera == 1) {
				firstPersonCamera.SetActive (false);
				thirdPersonCamera.SetActive (true);
				charcterBody.SetActive (true);
				activeCamera = 0;
			}
		}
	}
}
