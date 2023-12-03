using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public int numberOfCollectibles = 10;

    void Start()
    {
        SpawnCollectibles();
    }

    void SpawnCollectibles()
    {
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-2f, 2f));
            Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
