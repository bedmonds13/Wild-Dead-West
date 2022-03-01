using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDie;
        GetComponent<ZombieAttack>().OnAttack += ZombieAnimator_OnAttack;
    }

    private void ZombieAnimator_OnAttack()
    {
        animator.SetInteger("AttackId", UnityEngine.Random.Range(1, 3));
        animator.SetTrigger("Attack");
    }

    private void ZombieAnimator_OnTookHit()
    {
        animator.SetTrigger("Hit");
    }

    private void ZombieAnimator_OnDie()
    {
        animator.SetTrigger("Die");
    }
}
