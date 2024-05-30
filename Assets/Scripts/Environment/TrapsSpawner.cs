using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapsSpawner : MonoBehaviour
{
    [SerializeField] private Trap[] _trapsPrefab;
    [SerializeField] private int _trapsSpawnedCount;

    private Transform[] _spawnPoints;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _spawnPoints = new Transform[_transform.childCount];
        InitSpawnPoints();
        Spawn();
    }

    private void InitSpawnPoints()
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            _spawnPoints[i] = _transform.GetChild(i);
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < _trapsSpawnedCount; i++)
        {
            Transform spawnPoint = _spawnPoints[GetRandomiseValue(0, _spawnPoints.Length)];

            while (spawnPoint.childCount != 0)
            {
                spawnPoint = _spawnPoints[GetRandomiseValue(0, _spawnPoints.Length)];
            }

            Instantiate(_trapsPrefab[GetRandomiseValue(0, _trapsPrefab.Length)], spawnPoint);
        }
    }

    private int GetRandomiseValue(int minValue, int maxValue)
    {
        int value = Random.Range(minValue, maxValue);
        return value;
    }
}
