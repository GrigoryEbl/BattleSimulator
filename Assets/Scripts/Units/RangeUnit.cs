using UnityEngine;

public class RangeUnit : Unit
{
    private RangeWeapon _rangeWeapon;
    private Transform _target;

    private void Start()
    {
        _rangeWeapon = (RangeWeapon)UnitWeapon;
    }

    private void OnValidate()
    {
        if (UnitWeapon is RangeWeapon == false)
            ResetWeapon();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Shoot()
    {        
        _rangeWeapon.Shoot(_target.position);
    }
}