using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isScatter;
    [SerializeField] private float _force;
    [SerializeField] private Unit _parent;

    private bool _isEnemy;

    private void Awake()
    {
        _isEnemy = _parent.IsEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _parent)
            return;
        
        if (other.TryGetComponent(out IDamageable damageable) && damageable.IsEnemy != _isEnemy)
            damageable.TakeDamage(_damage);

        if(other.TryGetComponent(out RagdollHandler ragdollHandler) && _isScatter)
        {
            Vector3 forceDirection = transform.forward;
            ragdollHandler.Hit(forceDirection * _force, transform.position);
        }
    }
}
