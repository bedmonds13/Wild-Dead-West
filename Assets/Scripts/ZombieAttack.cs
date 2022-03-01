using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How long the zombie waits after next attempt to attack")]
    private float delayBetweenAttacks = 1.5f;

    [SerializeField]
    [Tooltip("How far away the zombie can attack from")]
    private float maximumAttackRange = 1.5f;

    [SerializeField]
    [Tooltip("Time before damage is dealt for animation to line up")]
    private float delayBetweenAnimationandDamage = 0.25f;

    public event Action OnAttack = delegate { };

    private float attackTimer;
    private int damage = 1;
    private Health health;
    private Health playerHealth;

    private void Start()
    {
        GetComponent<Health>().OnDied += Health_OnDied;
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Health_OnDied()
    {
        this.enabled = false;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (CanAttack())
        {
            Attack();
        }
    }

    private void Attack()
    {
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
        attackTimer = 0;
        
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationandDamage);
        playerHealth.TakeHit(damage);
    }

    private bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks &&
            Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    }
}
