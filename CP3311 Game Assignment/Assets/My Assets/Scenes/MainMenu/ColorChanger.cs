using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public Text text;
	float num;
	float red = 0.1f;
	float green = 0.4f;
	float blue = 0.7f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//taste the rainbow
		num = Random.value * 0.02f;
		red += num;
		if (red >= 1f) {
			red = 0f;
		}
		green += num;
		if (green >= 1f) {
			green = 0f;
		}
		blue += num;
		if (blue >= 1f) {
			blue = 0f;
		}
		text.color = new Color (red, green, blue);
	}
}
