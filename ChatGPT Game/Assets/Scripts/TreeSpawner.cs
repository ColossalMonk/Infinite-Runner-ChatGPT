using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
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
            float randomRotation = Random.Range(0, 360); // generate random rotation on y-axis
            Quaternion rotation = Quaternion.Euler(0, randomRotation, 0);
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, rotation);
            spawnedObject.transform.parent = spawnPoint;
        }
    }
}
