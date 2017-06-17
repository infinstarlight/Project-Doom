using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public bool lockCursor = true;

    public float followSpeed = 10;
    public float yawSpeed = 10;
    public float pitchSpeed = 50;

    public Transform playerTransform;
    public Transform yawPivot;
    public Transform pitchPivot;

    // Use this for initialization
    void Start () {
	
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * followSpeed);

        Vector3 yawRotation = yawPivot.localRotation.eulerAngles;
        yawRotation.y = Mathf.LerpAngle(yawRotation.y, playerTransform.localRotation.eulerAngles.y, Time.deltaTime * yawSpeed);
        yawPivot.localRotation = Quaternion.Euler(yawRotation);

        Vector3 pitchRotation = pitchPivot.localRotation.eulerAngles;
        pitchRotation.x -= Input.GetAxis("Mouse Y") * Time.deltaTime * pitchSpeed;
        pitchPivot.localRotation = Quaternion.Euler(pitchRotation);

        //Limit the angle
        if (pitchPivot.localRotation.eulerAngles.x > 55 && pitchPivot.localRotation.eulerAngles.x < 90)
        {
            pitchRotation = pitchPivot.localRotation.eulerAngles;
            pitchRotation.x = 55;
            pitchPivot.localRotation = Quaternion.Euler(pitchRotation);
        }
        else if (pitchPivot.localRotation.eulerAngles.x < 335 && pitchPivot.localRotation.eulerAngles.x > 90)
        {
            pitchRotation = pitchPivot.localRotation.eulerAngles;
            pitchRotation.x = 335;
            pitchPivot.localRotation = Quaternion.Euler(pitchRotation);
        }

	}
}
