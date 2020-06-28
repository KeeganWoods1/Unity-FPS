using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnDelay = 0.75f;


    public IEnumerator SpawnWave(int numberOfEnemies)
    {
        enemy.GetComponent<EnemyHealth>().maxHits += 5;
        enemy.GetComponent<NavMeshAgent>().speed += 0.1f;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        FindObjectOfType<EnemySpawnController>().currentEnemyCount++;

        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
