using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musket : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _startPoint;

    public void RaycastShoot(Transform target)
    {
        Vector3 direction = target.position - _startPoint.position;

        if (Physics.Raycast(_startPoint.position, direction, out RaycastHit hitInfo, _maxDistance, _layerMask))
        {
            Debug.DrawLine(_startPoint.position, hitInfo.point, Color.yellow, Vector3.Distance(_startPoint.position, hitInfo.point));
            var health = hitInfo.collider.GetComponentInParent<IDamageable>();
            health.TakeDamage(_damage);

            print("Shoot in " + hitInfo.collider.name);
        }
    }
}
