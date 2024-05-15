using System;
using UnityEngine;

[RequireComponent(typeof(MeleeWeapon))]
public class Arrow : Projectile
{
    private MeleeWeapon _weapon;

    private void OnEnable()
    {
        if (_weapon == null)
            SetWeapon();

        _weapon.enabled = true;
        _weapon.Hited += OnHited;
    }

    private void OnDisable()
    {
        _weapon.Hited -= OnHited;
    }

    private void SetWeapon()
    {
        _weapon = GetComponent<MeleeWeapon>();
        _weapon.SetBattleSide(IsEnemy);
    }

    private void OnHited()
    {
        _weapon.enabled = false;
        Push();
    }
}