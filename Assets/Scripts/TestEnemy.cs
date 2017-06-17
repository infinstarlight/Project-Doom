using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

	public int baseHealth;
	public float currentHealth;

	public Color lerpedColor = Color.blue;



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		if (currentHealth <= baseHealth) {
			lerpedColor = Color.Lerp (Color.white, Color.red, Mathf.PingPong (Time.time, 1));
		}
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Projectile") {
			currentHealth--;
			Debug.Log ("Ouch!");
		}
	}
}
