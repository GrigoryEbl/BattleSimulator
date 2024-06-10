using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Musket : RangeWeapon
{
    private readonly int _penetrationCount = 3;

    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private AudioSource _audioEffect;

    public override void Shoot(Vector3 targetPosition)
    {
        base.Shoot(targetPosition);

        AudioSource.PlayClipAtPoint(_audioEffect.clip, transform.position);
        _shootEffect.Play();
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

                if (targets.Count == _penetrationCount)
                    break;
            }
        }
    }
}