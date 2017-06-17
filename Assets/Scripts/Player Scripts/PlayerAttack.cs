using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PlayerAtrribute playerAttr;
	public float meleeCooldownInterval = 1;
	float MeleeCooldownTime = 0;

	ArrayList nearbyEnemy;

	// Use this for initialization
	void Start ()
	{

		nearbyEnemy = new ArrayList ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButtonDown ("Melee")) {
			if (Time.time > MeleeCooldownTime) {
				if (nearbyEnemy.Count > 0) {
					for (int i = 0; i < nearbyEnemy.Count; i++) {
						(nearbyEnemy [i] as GameObject).GetComponent<EnemyAI> ().GetDamage (playerAttr.attackDamage);
					}
				}
			}
		}
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Enemy") {
			nearbyEnemy.Add (col.gameObject);
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Enemy") {
			for (int i = 0; i < nearbyEnemy.Count; i++) {
				if (nearbyEnemy [i] == col.gameObject) {
					nearbyEnemy.RemoveAt (i);
				}
			}
		}
	}
}
