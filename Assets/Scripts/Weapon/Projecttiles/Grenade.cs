using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bomb
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    protected override void Explode()
    {
        List<IDamageable> targets = new List<IDamageable>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.TryGetComponent(out IDamageable target) && !targets.Contains(target))
            {
                target.TakeDamage(_damage);
                targets.Add(target);
                target.Hit(Vector3.up * _force, transform.position);
                //target.ExplosionHit(_force, transform.position, _radius);
                Debug.Log("�����!");
            }
        }

        Push();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,_radius);
    }
}