using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{
/*	public int startingHealth = 60;		(where 60 = 100%)
 * 		The amount of health the player starts the game with.	(This value is irrelevant since it is not used.)
 */
	public float currentHealth;		// The current health the player has.
	GameObject sliderObject;
	Slider healthSlider;			// Reference to the UI's health bar.
	GameObject damageObject;
	Image damageImage;												// Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;									// The speed the damageImage will fade at.
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);		// The colour the damageImage is set to, to flash.

	Animator anim;					// Reference to the Animator component.
	bool isDead;					// Whether the player is dead.
	bool damaged;					// True when the player gets damaged.
	float attackDelay;

	void Start ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		sliderObject = GameObject.FindGameObjectWithTag ("HealthSlider");
		healthSlider = sliderObject.GetComponent<Slider> ();
		damageObject = GameObject.FindGameObjectWithTag ("DamageImage");
		damageImage = damageObject.GetComponent<Image> ();

		// Set the initial health of the player.
		currentHealth = healthSlider.value;
	
		attackDelay = 0f;
	}

	void Update ()
	{
		attackDelay += Time.deltaTime;

		// If the player has just been damaged...
		if (damaged) {
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
        // Otherwise...
        else {
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
	}

	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		if (attackDelay > 0.5f) {
			damaged = true;

			// Reduce the current health by the damage amount.
			currentHealth -= amount;
			attackDelay = 0;
		}
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if (currentHealth <= 0 && !isDead) {
			// ... it should die.
			Death ();
		}
	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		// Tell the animator that the player is dead.
		anim.SetTrigger ("Die");
	}

	public bool GetIsDead ()
	{
		return isDead;
	}

//    public void RestartLevel ()
//    {
//        // Reload the level that is currently loaded.
//        SceneManager.LoadScene (0);
//    }
}