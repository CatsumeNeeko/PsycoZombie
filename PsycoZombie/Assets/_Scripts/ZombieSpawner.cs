using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject zombie;
    public Transform spawnPoint;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private bool shouldUpdate = true;

    private void Update()
    {
        if (shouldUpdate)
        {
            if (gameManager.gameStarted)
            {
                InvokeRepeating("SpawnZombie", Random.Range(minSpawnInterval, minSpawnInterval), Random.Range(maxSpawnInterval, maxSpawnInterval));
                shouldUpdate = false;
            }
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);
        Invoke("SpawnZombie", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
