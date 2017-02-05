using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthAmy : MonoBehaviour {

    public int baseHealth = 125;
    public int currentHealth;
    public Slider HealthSlider;
    public Image damageImage;
    public AudioClip deathSound;


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement AmyControlScript;
    bool isDead;
    bool Damaged;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
