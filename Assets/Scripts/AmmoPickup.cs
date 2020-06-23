using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 25;
    Ammo ammoSlot;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag != "Player") { return; }

        else
        {
            ammoSlot = other.GetComponent<Ammo>();

            ammoSlot.IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }


}
