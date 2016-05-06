using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 3;
	public int currentHealth;
	//public Slider healthSlider;
	//public Image damageImage;
	//public AudioClip deathClip;
	public float flashSpeed = 5f;
	// The speed the damageImage will fade at.
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	Animator anim;
	//AudioSource playerAudio;
	private bool isDead;
	private bool damaged;
	float attackDelay;

//	public GameObject player = GameObject.FindWithTag ("Player");
//	public GameObject SpawnPoint = GameObject.FindWithTag ("Respawn");
//	private Transform SpawnPoint;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		//playerAudio = GetComponent <AudioSource> ();
		currentHealth = startingHealth;	
		attackDelay = 0f;

//		SpawnPoint.position = GameObject.FindWithTag ("Respawn").transform;
	}

	void Update ()
	{
		attackDelay += Time.deltaTime;

		if (damaged) {
			//damageImage.color = flashColour;
		} else {
			//damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;
	}

	public void TakeDamage (int amount)
	{
		if (attackDelay > 0.5f) {
			damaged = true;
			currentHealth -= amount;
			attackDelay = 0;
		}

		//healthSlider.value = currentHealth;
		//playerAudio.Play ();

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
//		anim.SetTrigger ("Die");
//		playerAudio.clip = deathClip;
//		playerAudio.Play ();

		Respawn ();
	}

	public void RestartLevel ()
	{
//		SceneManager.LoadScene (0);
	}

	void OnTriggerEnter (Collider boundaryTrigger)
	{
		if (boundaryTrigger.gameObject.tag == "Boundary") {
			isDead = true;
		}
	}

	public void Respawn ()
	{
//		this.gameObject.transform.position = SpawnPoint.transform.position;
//		player.transform.position = SpawnPoint.transform.position;
		isDead = false;
	}
}
