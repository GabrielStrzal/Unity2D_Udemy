using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBtwSpawns;
    public float decreaseTime;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {

        if(player != null)
        {
            if (timeBtwSpawns <= 0)
            {
                //Spawn Hazard
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                //spawn objects
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                if (startTimeBtwSpawns > minTimeBtwSpawns)
                {
                    startTimeBtwSpawns -= decreaseTime;
                }


                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
