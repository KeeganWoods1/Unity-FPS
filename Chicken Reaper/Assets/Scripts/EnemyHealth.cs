using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] AudioClip chickenDeathSFX;
    [SerializeField] GameObject[] ammoBoxes;
    [SerializeField] float ammoDropProbability = 0.1f;
    public float maxHits = 100;

    EnemySpawnController enemySpawnController;
    AudioSource audioSource;

    bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        maxHits -= damage;

        if (maxHits <= 0 && !isDead)
        {
            DeathSequence();
        }
    }

    public void DeathSequence()
    {
        isDead = true;

        enemySpawnController = FindObjectOfType<EnemySpawnController>();
        enemySpawnController.currentEnemyCount--;
        audioSource.PlayOneShot(chickenDeathSFX);
        deathExplosion.Play();
        RandomlyDropAmmo();
        Destroy(gameObject, 0.5f);
    }

    private void RandomlyDropAmmo()
    {       
        if (UnityEngine.Random.Range(0.0f, 1.0f) <= ammoDropProbability)
        {
            Instantiate(ammoBoxes[UnityEngine.Random.Range(0, ammoBoxes.Length - 1)], transform.position, Quaternion.identity);
        }
    }
}
