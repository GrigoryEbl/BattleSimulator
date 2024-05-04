using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isScatter;
    [SerializeField] private float _force;

    private Unit _parent;
    private bool _isEnemy;

    public event Action Hit;

    private void Awake()
    {
        _parent = GetComponentInParent<Unit>();
        _isEnemy = _parent.IsEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_parent != null && other.transform == _parent)
            return;

        if (other.TryGetComponent(out IDamageable damageable) && damageable.IsEnemy != _isEnemy)
        {
            damageable.TakeDamage(_damage);
            Hit?.Invoke();
            print("Hit " + other.name + "Health:" + damageable.Health);
        }

        if (other.TryGetComponent(out RagdollHandler ragdollHandler) && _isScatter)
        {
            Vector3 forceDirection = transform.forward;
            ragdollHandler.Hit(forceDirection * _force, transform.position);
        }

    }
}
