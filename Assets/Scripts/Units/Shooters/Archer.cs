using UnityEngine;

public class Archer : Unit
{
    [SerializeField] private Bow _bow;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _parabolaRootPrefab;

    public void Shoot()
    {
        _bow.Shoot(SetDirection(_target), transform);
    }

    private void Update()
    {
        transform.LookAt(_target);
    }

    private Transform SetDirection(Transform target)
    {
        float distance = Vector3.Distance(transform.localPosition, target.position);

        _parabolaRootPrefab.GetChild(0).position = _parabolaRootPrefab.position;
        _parabolaRootPrefab.GetChild(1).localPosition = new Vector3(_parabolaRootPrefab.localPosition.x, distance / 3, distance / 2);// магические числа
        _parabolaRootPrefab.GetChild(2).position = _target.position;

        return _parabolaRootPrefab;
    }
}
