using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuidingSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // list of objects to spawn
    public Transform[] spawnPoints; // list of spawn points

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];
            Transform spawnPoint = spawnPoints[i];
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.transform.parent = spawnPoint;
        }
    }
}
