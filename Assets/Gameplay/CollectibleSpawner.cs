using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public GameObject powerUpPrefab;
    public GameObject enemyPrefab;
    public int numberOfCollectibles = 10;
    public int numberOfPowerUps = 3;
    public int numberOfEnemies = 5;

    public Vector2 spawnArea = new Vector2(10f, 4f);
    public float spawnPadding = 1f;

    private void Start()
    {
        SpawnCollectibles();
        SpawnPowerUps();
        SpawnEnemies();
    }

    void SpawnCollectibles()
    {
        SpawnObjects(collectiblePrefab, numberOfCollectibles);
    }

    void SpawnPowerUps()
    {
        SpawnObjects(powerUpPrefab, numberOfPowerUps);
    }

    void SpawnEnemies()
    {
        SpawnObjects(enemyPrefab, numberOfEnemies);
    }

    void SpawnObjects(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPosition = FindFreeSpawnPosition(prefab);
            Instantiate(prefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    Vector2 FindFreeSpawnPosition(GameObject prefab)
    {
        for (int attempt = 0; attempt < 10; attempt++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
            Collider2D[] colliders = Physics2D.OverlapBoxAll(randomPosition, prefab.GetComponent<SpriteRenderer>().bounds.size + new Vector3(spawnPadding, spawnPadding, 0), 0);

            // Check if the area is clear and there is ground below
            if (colliders.Length == 0 && HasGroundBelow(randomPosition, prefab))
            {
                return randomPosition;
            }
        }

        Debug.LogWarning("Failed to find a free spawn position after 10 attempts. Returning (0, 0).");
        return Vector2.zero;
    }

    bool HasGroundBelow(Vector2 position, GameObject prefab)
    {
        float raycastDistance = 2f; 

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, raycastDistance);

        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            // Ensure the object won't spawn inside another ground collider
            Collider2D[] colliders = Physics2D.OverlapBoxAll(position, prefab.GetComponent<SpriteRenderer>().bounds.size, 0);
            return colliders.Length == 0;
        }

        return false;
    }
}
