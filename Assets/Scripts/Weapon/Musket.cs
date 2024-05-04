using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musket : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _startPoint;

    private int _penetrationCount = 3;

    public void RaycastShoot(Transform target)
    {
        int currentPenetrations = _penetrationCount;

        Vector3 direction = target.position - _startPoint.position;

        RaycastHit[] hits = Physics.RaycastAll(_startPoint.position, direction, _maxDistance);
        Debug.DrawLine(_startPoint.position, hits[^1].point, Color.yellow, 3);

        hits = SortArray(hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (currentPenetrations == 0)
                return;

            if (hits[i].collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);

                print("Shoot in " + hits[i].collider.name + " Health: " + damageable.Health);

                currentPenetrations--;
            }
        }

    }

    private RaycastHit[] SortArray(RaycastHit[] hits)
    {
        RaycastHit temp;

        for (int i = 0; i < hits.Length; i++)
        {
            for (int j = i + 1; j < hits.Length; j++)
            {
                if (hits[i].distance > hits[j].distance)
                {
                    temp = hits[i];
                    hits[i] = hits[j];
                    hits[j] = temp;
                }
            }
        }

        return hits;
    }
}
