using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    public void SpawnEnemy(int difficultyMod)
    {
        enemy.GetComponent<EnemyHealth>().maxHits *= difficultyMod;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
