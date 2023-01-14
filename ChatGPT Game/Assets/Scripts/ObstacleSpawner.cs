using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // list of objects to spawn
    public Transform[] spawnPoints; // list of spawn points
    public float spawnProbability = 0.2f; // probability of spawning an object
    public List<GameObject> nonRotatableObjects; // list of objects that should not be rotated

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.value < spawnProbability)
            {
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                GameObject objectToSpawn = objectsToSpawn[randomIndex];
                Transform spawnPoint = spawnPoints[i];
                Quaternion rotation;
                if (!nonRotatableObjects.Contains(objectToSpawn))
                {
                    float randomRotation = Random.Range(0, 360); // generate random rotation on y-axis
                    rotation = Quaternion.Euler(0, randomRotation, 0);
                }
                else
                {
                    rotation = objectToSpawn.transform.rotation;
                }
                GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, rotation);
                spawnedObject.transform.parent = spawnPoint;
            }
        }
    }
}
