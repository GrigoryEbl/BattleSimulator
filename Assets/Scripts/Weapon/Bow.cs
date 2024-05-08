using UnityEngine;

[RequireComponent(typeof(ProjectilesPool))]
public class Bow : RangeWeapon
{
    [SerializeField] private NewProjectile _arrow;
    [SerializeField] private float _force;

    private ProjectilesPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ProjectilesPool>();
    }

    public override void Shoot()
    {
        Debug.Log(_pool);
        var arrow = _pool.Pull();
        arrow.gameObject.SetActive(true);
        arrow.Hurl(StartPoint, _force, IsEnemy);
    }
}