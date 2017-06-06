using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

	public NavMeshAgent agent;
	public float healthPoint = 50;
	public Animator animator;
	public GameObject player;


	// Use this for initialization
	void Start ()
	{

		GameObject.FindWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (player != null) {
			if (Vector3.Distance (transform.position, player.transform.position) <= 6) {
				//Move towards player
				agent.SetDestination (player.transform.position);
				Debug.Log ("I see you!");
				//Pass movement to animator
				animator.SetFloat ("VSpeed", agent.velocity.magnitude);
				animator.SetFloat ("HSpeed", 1f);
			}
		}
		
	}

	public void GetDamage (float damage)
	{
		healthPoint -= damage;

		if (healthPoint <= 0) {
			Die ();
		}
	}

	void Die ()
	{
		Destroy (gameObject);
	}
}
