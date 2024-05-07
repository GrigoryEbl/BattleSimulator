using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Musket : MonoBehaviour
{
    private readonly int _penetrationCount = 3;

    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _startPoint;

    private bool _isEnemy;

    public void SetBattleSide(bool isEnemy)
    {
        _isEnemy = isEnemy;
    }

    public void RaycastShoot()
    {
        RaycastHit[] hits = Physics.RaycastAll(_startPoint.position, _startPoint.forward, _maxDistance, _layerMask, QueryTriggerInteraction.Collide);

        CalculateHits(hits);
    }

    private void CalculateHits(RaycastHit[] hits)
    {
        List<IDamageable> targets = new List<IDamageable>();

        var sortedHits = hits.OrderBy(hit => hit.distance);

        foreach (var hit in sortedHits)
        {
            if (hit.collider.TryGetComponent(out IDamageable target) && !targets.Contains(target) && target.IsEnemy != _isEnemy)
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