using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private KeyCode weaponHotKey;
    [SerializeField]
    private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;

    public event Action OnFire = delegate { };

    public KeyCode WeaponHotKey { get { return weaponHotKey; } }

    public bool IsInAimMode {get { return Input.GetMouseButton(1) == false; } }

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
                Fire();
        }
    }

    private bool CanFire()
    {
        if (ammo != null && ammo.IsAmmoReady() == false)
            return false;

        return fireTimer >= fireDelay;
    }
    private void Fire()
    {
        fireTimer = 0;
        if (OnFire != null)
            OnFire();
    }
}
