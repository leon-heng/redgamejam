using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject coin; 
    public GameObject obstacle; 
    public float minInterval = 1f; 
    public float maxInterval = 3f; 
    public float minX = -1.8f; 
    public float maxX = 1.8f; 

    private float spawnTimer;
    private float timeToNextSpawn;

    private float obstacleChance = 0.2f;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeToNextSpawn)
        {
            SpawnObjects();
            spawnTimer = 0f;
            SetNextSpawnTime();
        }
    }

    void SpawnObjects()
    {
        int amountOfItem = Random.Range(1, 3); 
        List<float> randomX = new List<float>();

        for (int i = 0; i < amountOfItem; i++)
        {
            float newX;
            do
            {
                newX = Random.Range(minX, maxX);
            } while (randomX.Contains(newX)); 

            randomX.Add(newX);
        }

        for (int i = 0; i < amountOfItem; i++)
        {
            float chance = Random.Range(0f, 1f);
            GameObject itemToSpawn = chance <= obstacleChance ? obstacle : coin;
            Instantiate(itemToSpawn, new Vector3(randomX[i], transform.position.y, 0), Quaternion.identity);
        }
    }

    void SetNextSpawnTime()
    {
        timeToNextSpawn = Random.Range(minInterval, maxInterval);
    }
}
