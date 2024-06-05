using System;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _strikeEffect;
    [SerializeField] private AudioSource _audioEffect;

    public event Action Hited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable target) && target.IsEnemy != IsEnemy)
            Attack(target);
    }

    protected virtual void Attack(IDamageable target)
    {
        target.TakeDamage(_damage);
        Hited?.Invoke();
        _strikeEffect.Play();
        _audioEffect.Play();
        AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
    }
}