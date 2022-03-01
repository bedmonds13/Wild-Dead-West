using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    private int ammo;
    private Weapon potentialWeapon;

    private void OnTriggerEnter(Collider other)
    {
        potentialWeapon = other.GetComponent<Inventory>().currentWeapon;
        
        if (potentialWeapon != null && potentialWeapon.GetComponent<WeaponAmmo>().isInfinite == false)
        {
            potentialWeapon.GetComponent<WeaponAmmo>().RefillAmmo();
        }
    }
}
