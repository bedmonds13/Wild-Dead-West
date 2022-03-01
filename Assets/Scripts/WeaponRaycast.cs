using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private PooledlMonoBehaviour decalPrefab;
    [SerializeField]
    private Transform firePoint;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ? Camera.main.ViewportPointToRay(Vector3.one / 2f) :
            new Ray(firePoint.position, firePoint.forward);
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            Health health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(1);
            }
            else
                SpawnDecal(hitInfo.point, hitInfo.normal);
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledlMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(1);
    }
}
