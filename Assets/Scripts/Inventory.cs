using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<Weapon> OnWeaponChanged = delegate { };

    [SerializeField]
    private Weapon[] weapons;
    public Weapon currentWeapon { get; private set; } 

    private void Start()
    {
        SwitchToWeapon(weapons[0]);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotKey))
            {
                SwitchToWeapon(weapon);
                
                break;
            }

        }
        
    }

    private void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
                currentWeapon = weaponToSwitchTo;
        }
        OnWeaponChanged(weaponToSwitchTo);
    }
}
