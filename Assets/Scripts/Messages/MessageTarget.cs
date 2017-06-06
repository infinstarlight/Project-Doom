using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTarget : MonoBehaviour, DamageMessage
{

	public void Message1 ()
	{
		{
			Debug.Log ("This is a test message");
		}
	}


	public void Message2 ()
	{
		{
			Debug.Log ("message test is a This");
		}
	}
}
