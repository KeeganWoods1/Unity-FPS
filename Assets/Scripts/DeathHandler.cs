using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject enemy;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        ResetEnemyDifficulty();
        DisplayDeathMenu();
    }

    private void ResetEnemyDifficulty()
    {
        enemy.GetComponent<EnemyHealth>().maxHits = 100;
        enemy.GetComponent<NavMeshAgent>().speed = 8f;
    }

    private void DisplayDeathMenu()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
