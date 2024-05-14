using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Musket : RangeWeapon
{
    private readonly int _penetrationCount = 3;

    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
<<<<<<< HEAD
    [SerializeField] private Transform _startPoint;
=======
    [SerializeField] private LayerMask _layerMask;
>>>>>>> 20eb9933200fa2ab1c070e939ebdab17667251d0

    public override void Shoot()
    {
        RaycastHit[] hits = Physics.RaycastAll(StartPoint.position, StartPoint.forward, _maxDistance, _layerMask, QueryTriggerInteraction.Collide);

        CalculateHits(hits);
    }

    private void CalculateHits(RaycastHit[] hits)
    {
        List<IDamageable> targets = new List<IDamageable>();

        var sortedHits = hits.OrderBy(hit => hit.distance);

        foreach (var hit in sortedHits)
        {
            if (hit.collider.TryGetComponent(out IDamageable target) && !targets.Contains(target) && target.IsEnemy != IsEnemy)
            {
                targets.Add(target);
                target.TakeDamage(_damage);
                Debug.Log("попал!");

                if (targets.Count == _penetrationCount)
                    break;
            }
        }
    }
}