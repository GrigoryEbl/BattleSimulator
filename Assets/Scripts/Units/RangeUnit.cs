using UnityEngine;

public class RangeUnit : Unit
{
    private RangeWeapon _rangeWeapon;

    private void Start()
    {
        _rangeWeapon = (RangeWeapon)UnitWeapon;
    }

    private void OnValidate()
    {
        if (UnitWeapon is RangeWeapon == false)
            ResetWeapon();
    }

    private void Shoot()
    {        
        _rangeWeapon.Shoot();
    }
}