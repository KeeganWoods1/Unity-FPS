using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] EnemySpawner[] enemySpawners;
    [SerializeField] GameObject alphaChicken;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI waveText;
    public int currentEnemyCount = 0;
    public int currentWave = 1;

    int numberOfEnemies = 1;


    private void Start()
    {
        SpawnAlphaChicken();
        waveText.enabled = false;
    }

    private void Update()
    {
        if (currentEnemyCount <= 0 && playerHealth.maxHits > 0)
        {
            waveText.text = "Wave: " + (currentWave + 1).ToString();
            waveText.enabled = true;

            StartCoroutine(GetComponent<WaveClearedHandler>().HandleWaveCleared(currentWave));
            BeginWaveSequence();
        }
    }

    private void SpawnAlphaChicken()
    {
        currentEnemyCount++;
        Instantiate(alphaChicken);
    }

    private void BeginWaveSequence()
    {
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            StartCoroutine(enemySpawner.SpawnWave(numberOfEnemies));
        }

        currentWave++;

        if ((currentWave % 2) == 0)
        {
            numberOfEnemies += 1;
        }
        
    }
}
