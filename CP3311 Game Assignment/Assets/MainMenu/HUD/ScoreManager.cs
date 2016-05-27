using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.


    Text text;                      // Reference to the Text component.
	float timer;

    void Awake ()
    {
        // Set up the reference.
        text = GetComponent <Text> ();

        // Reset the score.
        score = 0;
		timer = 0f;
    }


    void Update ()
    {
		timer += Time.deltaTime;

		if (timer < 2f) {
			// Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Score: " + score;
		} else {
			text.text = "";
		}
		
    }

	public void AddScore (int points, int pointsType) 
	{
		score += points;
		timer = 0f;
	}

	public void SubScore (int points) {
		score += points;
		if (score < 0) {
			score = 0;
		}
	}

	public int GetScore () {
		return score;
	}
}