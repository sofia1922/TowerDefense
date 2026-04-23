using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] waypoints; 

    public EnemyData[] enemyTypes;
    public GameObject enemyPrefab;
    public int currentWaveBudget = 200;
    public float spawnInterval = 1.0f;

    void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        if (waypoints.Length > 0 && enemyTypes.Length > 0)
        {
            StartCoroutine(SpawnWaveRoutine());
        }
    }

    IEnumerator SpawnWaveRoutine()
    {
        int remainingBudget = currentWaveBudget;
        while (remainingBudget >= 10)
        {
            EnemyData randomEnemy = enemyTypes[Random.Range(0, enemyTypes.Length)];
            if (remainingBudget >= randomEnemy.attackCost)
            {
                SpawnEnemy(randomEnemy);
                remainingBudget -= randomEnemy.attackCost;
                yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
            }
            else yield return null;
        }
    }

    void SpawnEnemy(EnemyData data)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null) enemyScript.Initialize(data, waypoints);
    }
} 