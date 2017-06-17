using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    public GameObject Enemy;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //public GameObject Robot;
    public WaitForSeconds RespawnTimer;

	// Use this for initialization
	void Start () {
        // InvokeRepeating("RespawnEnemy", 2.0f, 20.0f);
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                //Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Enemy);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            
        }
    }


    //void RespawnEnemy()
    //{
    //    //      Instantiate(gameObject);
    //    Instantiate(Robot);
    //        //Method is run
        
    //}
}
