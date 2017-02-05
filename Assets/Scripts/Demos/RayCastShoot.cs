using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour {

    //Determine how much damage is a applied, control how often PC can fire
    public int gunDamage = 1;
    public float fireRate = .25f;

    //Determine how far ray will be cast into scene, if ray hits a rigidbody, apply force
    public float weaponRange = 50f;
    public float hitForce = 100f;

    //Transform component of Empty GameObject, marking where laser line begins
    public Transform gunEnd;

    //Reference to FP Camera to determine where the player is aiming from
    private Camera fpsCam;

    //Create WFS variable and initialize, create an array and hold the time for the player to be allowed to fire
    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);
    private LineRenderer laserLine;
    private float nextFire;

    //Audio Source
    private AudioSource gunAudio;

	// Use this for initialization
	void Start () {
        //Get and store reference to LineRender component and AudioSource
        //Get and store reference to FP Cam
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        //Controlling player fire rate
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            

            //Casting the Ray
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce); 
                }
            }
            else
            {
                laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
            }
        }
    }
        private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}

