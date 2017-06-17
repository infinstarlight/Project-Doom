using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthAmy : MonoBehaviour
{

	public int baseHealth;
	public float currentHealth;
	public Slider HealthSlider;
	public AudioClip deathSound;
	public GameObject RifleEquip;
	public float PlayerExperience;


	private Animator myAnimator;
	AudioSource playerAudio;
	PlayerMovement AmyControlScript;

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

	// Use this for initialization
	void Start ()
	{
        UpdateHealth(15);
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Debug Function
		if (Input.GetKeyDown (KeyCode.Slash)) {
			currentHealth--;
			Debug.Log ("I'm hit!");
		}
		if (currentHealth <= 0) {
			PlayerDeath ();
			
		}
	}

	void PlayerDeath ()
	{
		myAnimator.Play ("death_from_right");
        Vector3 deathpoint = new Vector3(0, 0, 0);
        AudioSource.PlayClipAtPoint(deathSound, deathpoint);
        Debug.Log("I am dead.");
        Destroy (gameObject);
	}

	void OnGUI ()
	{
		//GUI.Box (new Rect (180, 180, 100, 180), "Stats");
		GUI.Label (new Rect (20, 400, 360, 60), "Health: " + currentHealth);
		GUI.Label (new Rect (20, 430, 360, 60), "XP: " + PlayerExperience);
	}

    void UpdateHealth(int amount)
    {
        currentHealth += amount;

        if (OnHealthUpdated != null)
            OnHealthUpdated();
    }
}
