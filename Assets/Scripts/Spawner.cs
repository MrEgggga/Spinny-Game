using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float startDelay;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab", startDelay, spawnRate);
    }

    void SpawnPrefab()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
