﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoQuantity;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoQuantity;
    }

    public void DecreaseAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoQuantity--;
    }

    public void IncreaseAmmo(AmmoType ammoType, int amount)
    {
        GetAmmoSlot(ammoType).ammoQuantity += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}