using UnityEngine;

public abstract class ProjectileStarter : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;

    public  void Shoot(Transform path, Transform parent)
    {
        Instantiate(_projectilePrefab, _spawnPoint.position, transform.rotation).Init(path, parent);
    }
}
