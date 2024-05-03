using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileStarter : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;

    public  void Shoot(Transform path)
    {
        Instantiate(_projectilePrefab, _spawnPoint.position, transform.rotation).Init(path);
    }
}
