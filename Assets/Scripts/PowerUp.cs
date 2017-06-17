using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PowerUp : MonoBehaviour {

    public float addHP = 0;
    public float IncreaseSpeed = 0;
    public int IncreaseDamage = 0;
    public AudioClip PickupSound;
    AudioSource impact;
    public GameObject PUP;
    

    void Start()
    {
        impact = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
            Health PCHealth = other.gameObject.GetComponent<Health>();
            PCHealth.player_health += addHP;
            PCHealth.bullet_damage += IncreaseDamage;
            impact.PlayOneShot(PickupSound);
            Destroy(gameObject, 0.99f);
            }
    }

    //void OnDestroy()
    //{
    //    Instantiate(PickupSound);    
    //}

}
