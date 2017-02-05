using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmyControlScript : MonoBehaviour {

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();

	}

    // Update is called once per frame
    void Update() {
        myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        myAnimator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100.0f);
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningLeft", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
        }

        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100.0f);
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningRight", true);
            }
        }
        else
        {
            myAnimator.SetBool("TurningRight", false);

        }
        if (Input.GetButtonDown("Jump"))
        {
            myAnimator.SetBool("Jumping", true);
            Invoke("StopJumping", 0.1f);
        }
        if(Input.GetKeyDown("c"))
        {
            if(myAnimator.GetInteger("CurrentAction") == 0)
            {
                myAnimator.SetInteger("CurrentAction", 1);
            }
           else if (myAnimator.GetInteger("CurrentAction") == 1)
            {
                myAnimator.SetInteger("CurrentAction", 0);
            }
        }
    }
        void StopJumping()
            {
            myAnimator.SetBool("Jumping", false);
        }

	}


