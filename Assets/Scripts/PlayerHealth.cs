using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHits = 15;

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
        FindObjectOfType<DeathHandler>().HandleDeath();
        print("You Died");
    }
}
