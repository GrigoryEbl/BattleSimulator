using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private float _force;
    [SerializeField] private Transform _spawnPoint;

    public void Shoot()
    {
        Instantiate(_arrowPrefab, _spawnPoint.position, transform.rotation).Init(_force);
    }
}
