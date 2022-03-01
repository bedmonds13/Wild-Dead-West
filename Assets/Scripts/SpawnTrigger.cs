using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private Spawner spawner;

    private void Awake()
    {
        spawner = GetComponentInParent<Spawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            spawner.isTriggerSetOff = true;
            spawner.HandleStartFightSequence();
        }
    }
}
