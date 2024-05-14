using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable target) && target.IsEnemy != IsEnemy)
            Attack(target);
    }

    protected virtual void Attack(IDamageable target)
    {
        target.TakeDamage(_damage);
    }
}