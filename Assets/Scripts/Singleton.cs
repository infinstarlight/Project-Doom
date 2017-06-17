using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a generic class, meaning we won't know it's type until runtime

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

	//Will instantiate an instance if one doesn't exist
	//Or will try to find an instance of itself

	private static T instance;

	public static T Instance {
		get {
			//Check if null instance
			if (instance == null) {
				//Find object already in scene
				instance = GameObject.FindObjectOfType<T> ();

				if (instance == null) {
					//Couldn't find singleton in scene, so instantiate
					GameObject singleton = new GameObject (typeof(T).Name);
					instance = singleton.AddComponent<T> ();
				}
			}
			return instance;
		}
	}

	public virtual void Awake ()
	{
		if (instance == null) {
			instance = this as T;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

}
