using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

	//The box's current health point total
	public int currentHealth = 3;

	public void Damage (int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;
		Debug.Log ("I'm being shot!");

		//Check if health has fallen below zero
		if (currentHealth <= 0) {
			//if health has fallen below zero, deactivate it 
			gameObject.SetActive (false);
			Debug.Log ("I'm dead!");
		}
	}
}
