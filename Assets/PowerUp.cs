using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float addHP = 0;
    public float IncreaseSpeed = 0;
    public int IncreaseDamage = 0;
    //public Health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
            Health PCHealth = other.gameObject.GetComponent<Health>();
            PCHealth.player_health += addHP;
            PCHealth.bullet_damage += IncreaseDamage;

            Destroy(gameObject);
            }
    }
}
