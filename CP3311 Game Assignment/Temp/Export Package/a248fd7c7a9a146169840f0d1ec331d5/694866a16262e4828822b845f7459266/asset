using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour
{
	public Light sunLight;
	public float dayCycle = 120f;				// derived from source's "secondsInFullDay"
	[Range (0, 1)]								// defines full day cycle, where 0 is midnight & 0.5 is noon
	public float currentTime = 0;				// (i.e. sunrise)
	[HideInInspector]
	public float timeMultiplier = 1f;

	float sunIntensity;

	void Start ()
	{
		sunIntensity = sunLight.intensity;
	}

	void Update ()
	{
		UpdateSun ();

		currentTime += (Time.deltaTime / dayCycle) * timeMultiplier;

		if (currentTime >= 1) {
			currentTime = 0;					// resets the time back to midnight after a full cycle
		}
	}

	void UpdateSun ()
	{
		sunLight.transform.localRotation = Quaternion.Euler ((currentTime * 360f) - 90, 170, 0);

		float intensityMultiplier = 1;

		if (currentTime <= 0.23f || currentTime >= 0.75f) {
			intensityMultiplier = 0;
		} else if (currentTime <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01 ((currentTime - 0.23f) * (1 / 0.02f));
		} else if (currentTime >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01 (1 - ((currentTime - 0.73f) * (1 / 0.02f)));
		}

		sunLight.intensity = sunIntensity * intensityMultiplier;
	}
}
