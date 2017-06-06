using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4AIScript : MonoBehaviour
{

	public Rigidbody projectileRB;
	
	public int gunDamage;
	public float fireRate;

	public float weaponRange;
	public AudioSource gunAudio;
	public float hitForce;

	public Transform gunEnd;

	public WaitForSeconds shotDuration = new WaitForSeconds (0.5f);
	private float nextFire;


	// Use this for initialization
	void Start ()
	{
		gunAudio = GetComponent<AudioSource> ();
		//playerAim = GetComponentInParent<Camera> ();
        

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			StartCoroutine (ShotEffect ());
		} else if (Input.GetButtonUp ("Fire1")) {
			StopCoroutine (ShotEffect ());
			//TODO Raycasting
		}
	}

	private IEnumerator ShotEffect ()
	{
		Rigidbody projInstance;
		projInstance = Instantiate (projectileRB, gunEnd.position, gunEnd.rotation) as Rigidbody;
		projInstance.velocity = transform.TransformDirection (Vector3.back * hitForce);
		gunAudio.Play ();
		Destroy (projInstance, 2);

		Vector3 fwd = transform.TransformDirection (Vector3.back);
		if (Physics.Raycast (transform.position, fwd, 10))
			Debug.Log ("I am hitting something in front of me!");
		

		yield return shotDuration;
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Destroy (gameObject);
			Debug.Log ("Weapon equipped.");
			//TODO Create weapon Equip function
		}
		if (other.tag == "Projectile")
		{
		    Destroy(gameObject);
		    Debug.Log("Projectile is removed, hopefully.");
		}
	}
}