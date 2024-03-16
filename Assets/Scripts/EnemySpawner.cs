using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private float timer = 0f;
    private DayNightCycle dayNightCycle;

    private void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightCycle>();
    }

    private void Update()
    {
        if (dayNightCycle && !dayNightCycle.isDaytime)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
        else
        {
            // If it's daytime, destroy all spawned enemies and clear the list
            foreach (var enemy in spawnedEnemies)
            {
                Destroy(enemy);
            }
            spawnedEnemies.Clear();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }
}
