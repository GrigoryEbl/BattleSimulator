using UnityEngine;

public class SpecialWeapon : MeleeWeapon
{
    [SerializeField] private float _force;

    protected override void Attack(IDamageable target)
    {
        base.Attack(target);
        target.Hit(transform.forward * _force, transform.position);
    }
}