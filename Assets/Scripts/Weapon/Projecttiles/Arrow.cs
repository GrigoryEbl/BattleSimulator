using UnityEngine;

[RequireComponent(typeof(MeleeWeapon))]
public class Arrow : Projectile
{
    private MeleeWeapon _weapon;

    private void OnEnable()
    {
        if (_weapon == null)
            SetWeapon();

        _weapon.Hited += OnHited;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
            Push();
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
        Push();
    }
}