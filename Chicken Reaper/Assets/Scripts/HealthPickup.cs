using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healAmount = 25;
    PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") { return; }

        else
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth.maxHits <= 75)
            {
                playerHealth.maxHits += 25;
            }

            else
            {
                playerHealth.maxHits = 100;
            }

            Destroy(gameObject);
        }
    }
}
