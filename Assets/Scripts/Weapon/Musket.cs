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

    private Vector3 _direction;

    public void RaycastShoot( Vector3 direction)
    {
        _direction = direction;

        if (Physics.SphereCast(_startPoint.position, _radius, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            var health = hitInfo.collider.GetComponent<IDamageable>();

            if (health != null)
            {
                health.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (Physics.Raycast(_startPoint.position, _direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            Gizmos.DrawLine(_startPoint.position, hitInfo.point);
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
        }
    }
}
