using UnityEngine;

[RequireComponent(typeof(ParabolaController))]
public class Arrow : Projectile
{
    private ParabolaController _parabolaController;
    private Weapon _weapon;

    private void OnEnable()
    {
        _weapon.Hit += Disable;
    }

    private void OnDisable()
    {
        _weapon.Hit -= Disable;
    }

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        _parabolaController = GetComponent<ParabolaController>();
    }

    public override void Init(Transform parabola)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
    }

    private void Disable()
    {
        _weapon.enabled = false;
        _parabolaController.enabled = false;
    }
}
