using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    public int numSelector;
    public GameObject[] enemies;
    public GameObject EnemySelector;
    public Transform[] waypoints;

	// Use this for initialization
	void Start () {

        waypoints = new Transform[transform.childCount];
        int i = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            GameObject enemieSpawn = Instantiate(EnemySelector, transform.parent, true);
        }
    }
}
