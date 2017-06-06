using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{

	public Camera overheadCamera;
	public Camera thirdpersonCamera;

	/*// Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update ()
	{

		if (thirdpersonCamera.enabled == false) {
			if (Input.GetKeyDown (KeyCode.F)) {
				ShowOverHead ();
			}
		} 
		if (overheadCamera.enabled == true) {
			if (Input.GetKeyDown (KeyCode.F)) {
				ShowThirdPerson ();
			}
		}
		
	}

	void ShowOverHead ()
	{
		thirdpersonCamera.enabled = false;
		overheadCamera.enabled = true;
	}

	void ShowThirdPerson ()
	{
		thirdpersonCamera.enabled = true;
		overheadCamera.enabled = false;
	}
}
