using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musket : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius = 0.01f;
    [SerializeField] private Transform _startPoint;

    public void RaycastShoot( Vector3 direction)
    {
        if (Physics.SphereCast(_startPoint.position, _radius, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            var health = hitInfo.collider.GetComponent<IDamageable>();

            if (health != null)
            {
                health.TakeDamage(_damage);
            }
        }
    }
}
