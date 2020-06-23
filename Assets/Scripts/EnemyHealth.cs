using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHits = 100;
    [SerializeField] ParticleSystem deathExplosion;

    public void TakeDamage(int damage)
    {
        maxHits -= damage;

        if (maxHits <= 0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        deathExplosion.Play();
        Destroy(gameObject, 0.5f);
    }
}
