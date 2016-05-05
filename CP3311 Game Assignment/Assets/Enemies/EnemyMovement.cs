using UnityEngine;
using System.Collections;



public class EnemyMovement : MonoBehaviour
{
	public float detectDistance;
	float distance;			//for debugging purposes
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
	Transform enemy;				// Reference to this enemy's position.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
	Animator anim;					
    NavMeshAgent nav;              
	float attackTimer;
	 


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemy = GetComponent <Transform> ();
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		attackTimer = 0f;


    }


    void Update ()
	{	
		distance = Vector3.Distance (enemy.position, player.position);			// checks how far away the player is
		//if player is within range enemy detects them
		if (distance <= detectDistance && distance > 1f) {
			anim.SetTrigger ("PlayerDetected");
			//if player is in attack range

			// If the enemy and the player have health left...
			if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
				// ... set the destination of the nav mesh agent to the player.
				nav.SetDestination (player.position);
			}

            // Otherwise...
            else {
					// ... disable the nav mesh agent.
					nav.enabled = false;
				}
			
		}
		//if enemy in attack range
		if (distance <= 1f) {

			anim.SetTrigger ("PlayerInAttackRange");

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f) {
				playerHealth.TakeDamage (10);
			}
		}
	}
	private float Distance()
	{
		return Vector3.Distance(enemy.position, player.position);
	}
}