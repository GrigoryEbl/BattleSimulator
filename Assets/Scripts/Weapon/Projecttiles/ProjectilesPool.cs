using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private Queue<Projectile> _spawnQueue = new Queue<Projectile>();

    public void Push(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _spawnQueue.Enqueue(projectile);
    }

    public Projectile Pull()
    {
        if (_spawnQueue.Count == 0)
            return CreateProjectile();

        return _spawnQueue.Dequeue();
    }

    private Projectile CreateProjectile()
    {
        var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.Initialize(this);
        return projectile;
    }
}