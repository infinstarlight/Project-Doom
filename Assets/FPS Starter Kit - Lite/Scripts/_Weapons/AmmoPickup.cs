using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GunScript PCGun;
    public RocketLauncher PCRL;
    public SnaiperRifle PCSR;


	public int addGunAmmo = 0;
	public int addRLAmmo = 0;
	public int addSRAmmo = 0;


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			PCGun.inventoryAmmo += addGunAmmo;
			PCRL.inventoryAmmo += addRLAmmo;
			PCSR.inventoryAmmo += addSRAmmo;
		}
	}

}