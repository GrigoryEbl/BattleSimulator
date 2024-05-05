using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poison : Projectile
{
    [SerializeField] private PoisonField _poisonFieldPrefab;

    private ParabolaController _parabolaController;
    private Rigidbody _rigidbody;
    private SphereCollider _sphereCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _parabolaController = GetComponent<ParabolaController>();
        _sphereCollider = GetComponent<SphereCollider>();

        _rigidbody.isKinematic = true;
    }

    public override void Init(Transform parabola)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ground ground) || other.TryGetComponent(out Unit unit))
            Ñrash();
    }

    private void Ñrash()
    {
        _rigidbody.isKinematic = false;
        _parabolaController.enabled = false;
        _sphereCollider.isTrigger = false;
        Instantiate(_poisonFieldPrefab);
    }
}
