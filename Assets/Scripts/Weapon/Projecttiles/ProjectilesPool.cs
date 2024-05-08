using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField] private NewProjectile _projectilePrefab;

    private Queue<NewProjectile> _spawnQueue = new Queue<NewProjectile>();

    public void Push(NewProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _spawnQueue.Enqueue(projectile);
    }

    public NewProjectile Pull()
    {
        if (_spawnQueue.Count == 0)
            return CreateProjectile();

        return _spawnQueue.Dequeue();
    }

    private NewProjectile CreateProjectile()
    {
        var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.Initialize(this);
        return projectile;
    }
}