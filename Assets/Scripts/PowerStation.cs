using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStation : MonoBehaviour {

    public GunScript PCGun;
    public RocketLauncher PCRL;
    public SnaiperRifle PCSR;
    public int hazardCount;
    public float reloadWait;
    public float startWait;
    public float dischargeWait;
    public WaitForSeconds ChargeTimer;

    //TODO Create function to activate function after Station is "charged"
    //TODO Edit OTE event to constantly reload player
    //TODO Create charge function


    public int addGunAmmo = 0;
    public int addRLAmmo = 0;
    //TODO Add New Weapon


   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PCGun.inventoryAmmo += addGunAmmo;
            PCRL.inventoryAmmo += addRLAmmo;
        }
    }
}
