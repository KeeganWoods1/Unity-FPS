using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] ParticleSystem bloodFX;
    [SerializeField] TextMeshProUGUI healthText;
    public int maxHits = 100;

    private void Update()
    {
        if (maxHits > 0)
        {
            healthText.text = "HP: " + maxHits.ToString();
        }
        else
        {
            healthText.text = "HP: 0";
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodFX, transform);
        maxHits -= damage;

        if (maxHits <= 0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        FindObjectOfType<DeathHandler>().HandleDeath();
    }
}
