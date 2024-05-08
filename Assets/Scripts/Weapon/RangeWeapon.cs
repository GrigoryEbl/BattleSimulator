using UnityEngine;

public abstract class RangeWeapon : Weapon
{
    [SerializeField] private Transform _startPoint;

    protected Transform StartPoint => _startPoint;

    public abstract void Shoot();
}