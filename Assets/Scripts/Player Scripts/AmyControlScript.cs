using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmyControlScript : MonoBehaviour
{

	public static AmyControlScript instance;

	private Animator myAnimator;

    //private ICustomMessageTarget

	void Awake ()
	{
		DontDestroyOnLoad (gameObject);
		instance = this;
		myAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		myAnimator.SetFloat ("VSpeed", Input.GetAxis ("Vertical"));
		myAnimator.SetFloat ("HSpeed", Input.GetAxis ("Horizontal"));
		if (Input.GetKey ("q")) {
			transform.Rotate (Vector3.down * Time.deltaTime * 100.0f);
			if ((Input.GetAxis ("Vertical") == 0f) && (Input.GetAxis ("Horizontal") == 0)) {
				myAnimator.SetBool ("TurningLeft", true);
			}

		} else {
			myAnimator.SetBool ("TurningLeft", false);
		}

		if (Input.GetKey ("e")) {
			transform.Rotate (Vector3.down * Time.deltaTime * 100.0f);
			if ((Input.GetAxis ("Vertical") == 0f) && (Input.GetAxis ("Horizontal") == 0)) {
				myAnimator.SetBool ("TurningRight", true);
			}
		} else {
			myAnimator.SetBool ("TurningRight", false);

		}
		if (Input.GetButtonDown ("Jump")) {
			myAnimator.SetBool ("Jumping", true);
			Invoke ("StopJumping", 0.1f);
		}
		if (Input.GetButtonDown ("Crouch")) {
			if (myAnimator.GetInteger ("CurrentAction") == 0) {
				myAnimator.SetInteger ("CurrentAction", 1);
			} else if (myAnimator.GetInteger ("CurrentAction") == 1) {
				myAnimator.SetInteger ("CurrentAction", 0);
			}
		}
		if (Input.GetButtonDown ("Fire1")) {
			myAnimator.SetBool ("Fire Rifle", true);
		} else if (Input.GetButtonUp ("Fire1")) {
			myAnimator.SetBool ("Fire Rifle", false);
		}
		if (Input.GetButtonDown ("Reload")) {
			myAnimator.SetBool ("Reload", true);
		} else if (Input.GetButtonUp ("Reload")) {
			myAnimator.SetBool ("Reload", false);
		}
		if (Input.GetButtonDown ("Melee")) {
			myAnimator.SetBool ("Melee", true);
		} else if (Input.GetButtonUp ("Melee")) {
			myAnimator.SetBool ("Melee", false);
		}
		if (Input.GetButtonDown ("Aiming")) {
			myAnimator.SetBool ("Player Aiming", true);
		} else if (Input.GetButtonUp ("Aiming")) {
			myAnimator.SetBool ("Player Aiming", false);
		}


		//create anim function for other weapons

		if (Input.GetKeyDown (KeyCode.I)) {
			myAnimator.SetBool ("Rifle is Equipped", true);
			Debug.Log ("Testing rifle animations.");
		}
		/* if (GameManager.instance.currentGameState == GameState.PauseMenu)
        {
            if (Input.GetButtonDown("Pause"))
            {

            }
        }*/

	}

	void StopJumping ()
	{
		myAnimator.SetBool ("Jumping", false);
	}
}


