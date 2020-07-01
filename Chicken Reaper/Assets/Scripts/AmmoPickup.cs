using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip ammoPickupSFX;
    [SerializeField] int ammoAmount = 25;
    Ammo ammoSlot;
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag != "Player") { return; }

        else
        {
            ammoSlot = other.GetComponent<Ammo>();
            GetComponent<AudioSource>().PlayOneShot(ammoPickupSFX);
            ammoSlot.IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject, 0.5f);
        }
    }


}
