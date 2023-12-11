using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public GameObject powerUpPrefab;
    public int numberOfCollectibles = 10;
    public int numberOfPowerUps = 3;

    void Start()
    {
        SpawnCollectibles();
        SpawnPowerUps();
    }

    void SpawnCollectibles()
    {
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-2f, 2f));
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
    
    void SpawnPowerUps()
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-2f, 2f));
            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
