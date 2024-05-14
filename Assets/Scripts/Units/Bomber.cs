using UnityEngine;

public class Bomber : Unit
{
    [SerializeField] private Transform _target;

    private Slingshot _rangeWeapon;

    private void Start()
    {
        _rangeWeapon = (Slingshot)UnitWeapon;
    }

    private void OnValidate()
    {
        if (UnitWeapon is Slingshot == false)
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