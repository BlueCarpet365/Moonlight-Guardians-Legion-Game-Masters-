using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;
    public int maxEnemies = 10;

    private int currentEnemies = 0;
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
            if (currentEnemies >= maxEnemies)
                return;

            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
}

