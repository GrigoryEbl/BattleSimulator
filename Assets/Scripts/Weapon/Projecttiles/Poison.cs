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
    private Transform _parent;
    private bool _isHit;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _parabolaController = GetComponent<ParabolaController>();
        _sphereCollider = GetComponent<SphereCollider>();

        _rigidbody.isKinematic = true;
        _isHit = false;
    }

    public override void Init(Transform parabola, Transform parent)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
        _parent = parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _parent)
            return;

        if (_isHit)
            return;

        if (other.TryGetComponent(out Unit unit) || other.TryGetComponent(out Ground ground))
        {
            _isHit = true;
            Ñrash(other.ClosestPoint(transform.position));
        }
    }

    private void Ñrash(Vector3 spawnPosition)
    {
        Instantiate(_poisonFieldPrefab, spawnPosition, Quaternion.identity);
        Disable();
    }

    private void Disable()
    {
        _parabolaController.enabled = false;
        _sphereCollider.isTrigger = false;
        _rigidbody.isKinematic = false;
        enabled = false;
    }
}
