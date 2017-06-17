using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public GameObject Enemy;
    public float SpawnDelay;
    private Transform EnemySpawnPoint;
    public WaitForSeconds RespawnTimer;
    public float startWait;
    public int enemyCount;
    public float spawnWait;
    public float waveWait;

    // Use this for initialization
    void Start () {
        EnemySpawnPoint = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            

        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                //Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Enemy);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


        }
    }
}
