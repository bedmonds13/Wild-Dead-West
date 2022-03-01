using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour
{
    [SerializeField]
    private int damage =1;
    private float damageTimer;
    private float damageDelay = 1f;

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null && damageTimer > damageDelay)
        {
            other.GetComponent<Health>().TakeHit(damage);
            damageTimer = 0;
        }
    }
}
