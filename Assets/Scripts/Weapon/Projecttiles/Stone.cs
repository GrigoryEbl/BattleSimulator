using UnityEngine;

public class Stone : Projectile
{
    private ParabolaController _parabolaController;
    private Rigidbody _rigidbody;
    private Weapon _weapon;
    private SphereCollider _sphereCollider;

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
        _rigidbody = GetComponent<Rigidbody>();
        _parabolaController = GetComponent<ParabolaController>();
        _sphereCollider = GetComponent<SphereCollider>();

        _rigidbody.isKinematic = true;
    }

    public override void Init(Transform parabola)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
    }

    private void Disable()
    {
        _weapon.enabled = false;
        _rigidbody.isKinematic = false;
        _parabolaController.enabled = false;
        _sphereCollider.isTrigger = false;
    }
}
