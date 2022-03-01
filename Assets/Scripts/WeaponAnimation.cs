using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponAnimation : WeaponComponent
{
    private Animator animator;
    private Weapon weapon;
    private void Awake()
    {
       weapon = GetComponent<Weapon>();
       animator = GetComponent<Animator>();
    } 
    // Start is called before the first frame update
    void Start()
    {
        weapon.OnFire += Weapon_OnFire;
    }

    private void Weapon_OnFire()
    {
        animator.SetTrigger("Fire");
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_OnFire;
    }

    protected override void WeaponFired()
    {
        throw new System.NotImplementedException();
    }
}
