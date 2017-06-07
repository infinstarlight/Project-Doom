using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

	public int addGunAmmo = 0;
	public int addRLAmmo = 0;
	public int addSRAmmo = 0;


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			GunScript PCGun = other.gameObject.GetComponentInChildren<GunScript> ();
			PCGun.inventoryAmmo += addGunAmmo;
			RocketLauncher PCRL = other.gameObject.GetComponentInChildren<RocketLauncher> ();
			PCRL.inventoryAmmo += addRLAmmo;
			/*SnaiperRifle PCSR = other.gameObject.GetComponentInChildren<SnaiperRifle> ();
			PCSR.inventoryAmmo += addSRAmmo;*/
		}
	}

}