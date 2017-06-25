using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackAnimScript : MonoBehaviour {

    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        myAnimator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
        if(Input.GetButtonDown("Jump"))
        {
            myAnimator.SetBool("isJumping", true);
        }

    }
}
