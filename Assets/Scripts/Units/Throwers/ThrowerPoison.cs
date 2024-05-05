using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerPoison : Unit
{
    [SerializeField] private ThrowHand _throwHand;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _parabolaRootPrefab;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Throw()
    {
        _throwHand.Shoot(SetDirection(_target), _transform);
    }

    private void Update()
    {
        _transform.LookAt(_target);
    }

    private Transform SetDirection(Transform target)
    {
        float distance = Vector3.Distance(_transform.localPosition, target.position);

        _parabolaRootPrefab.GetChild(0).position = _parabolaRootPrefab.position;
        _parabolaRootPrefab.GetChild(1).localPosition = new Vector3(_parabolaRootPrefab.localPosition.x, distance / 3, distance / 2);// магические числа
        _parabolaRootPrefab.GetChild(2).position = _target.position;

        return _parabolaRootPrefab;
    }
}
