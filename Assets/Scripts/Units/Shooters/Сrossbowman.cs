using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сrossbowman : Unit
{
    [SerializeField] private Crossbow _crossbow;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _parabolaRootPrefab;

    public void Shoot()
    {
        _crossbow.Shoot(SetDirection(_target), transform);
    }

    private void Update()
    {
        transform.LookAt(_target);
    }

    private Transform SetDirection(Transform target)
    {
        float distance = Vector3.Distance(transform.localPosition, target.position);

        _parabolaRootPrefab.GetChild(0).position = _parabolaRootPrefab.position;
        _parabolaRootPrefab.GetChild(1).localPosition = _parabolaRootPrefab.position;
        _parabolaRootPrefab.GetChild(2).position = _target.position;

        return _parabolaRootPrefab;
    }
}