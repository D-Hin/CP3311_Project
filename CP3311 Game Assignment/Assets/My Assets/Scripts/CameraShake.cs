using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	/* Script has been modified from the original at https://gist.github.com/ftvs/5822103
	 * I acknowledge the original author "ftvs" from GitHub.
	 */

	//Transform of the camera to shake.
	public Transform camTransform;

	//How long is the camera going to shake for.
	public float shakeDuration = 0f;

	//Amplitude of the shake. A larger value will shake the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseShake = 0.5f;
	public float decreaseFactor = 1.5f;

	Vector3 originalPos;

	void Awake() {
		if (camTransform == null) {
			camTransform = GetComponent (typeof(Transform)) as Transform;
		}
	}

	void OnEnable () {
		originalPos = camTransform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
			shakeAmount -= Time.deltaTime * decreaseShake;
		} 
		else {
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}

	}

	public void Shake(float duration, float intensity) {
		shakeDuration += duration;
		shakeAmount = intensity;
	}
}
