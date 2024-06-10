using UnityEngine;

[RequireComponent(typeof(MeleeWeapon))]
public class Arrow : Projectile
{
    private MeleeWeapon _weapon;

    private void OnEnable()
    {
        if (_weapon == null)
            _weapon = GetComponent<MeleeWeapon>();

        _weapon.Hited += OnHited;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            Push();
    }

    private void OnDisable()
    {
        _weapon.Hited -= OnHited;
    }

    public override void Initialize(ProjectilesPool pool, bool isEnemy)
    {
        base.Initialize(pool, isEnemy);
        
        _weapon.SetBattleSide(IsEnemy);
    }

    private void OnHited()
    {
        Push();
    }
}