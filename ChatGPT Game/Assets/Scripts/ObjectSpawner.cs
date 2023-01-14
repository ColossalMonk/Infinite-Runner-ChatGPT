using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // the object to spawn
    public float spawnInterval = 5f; // time interval between spawning objects
    private float spawnTimer; // timer for spawn interval

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime; // Decrement the spawn timer
        if (spawnTimer <= 0)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedObject.transform.parent = transform; // setting the parent of the spawned object to the current gameobject
    }
}
