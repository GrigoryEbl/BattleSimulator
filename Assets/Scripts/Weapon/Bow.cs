using UnityEngine;

[RequireComponent(typeof(ProjectilesPool))]
public class Bow : RangeWeapon
{
    [SerializeField] private float _force;

    private ProjectilesPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ProjectilesPool>();
        _pool.Initialize(IsEnemy);
    }

    public override void Shoot()
    {
        var arrow = _pool.Pull();
        arrow.gameObject.SetActive(true);
        arrow.Hurl(StartPoint, StartPoint.forward * _force);
    }
}