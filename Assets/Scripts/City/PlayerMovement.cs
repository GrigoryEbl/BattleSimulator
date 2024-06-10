using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
internal class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public event Action<bool> Moving;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _transform.LookAt(_transform.position + direction);
        _rigidbody.velocity = direction * _speed;
        IsMoving = true;
        Moving?.Invoke(IsMoving);
    }

    public void Stop()
    {
        if (_rigidbody != null)
            _rigidbody.velocity = Vector3.zero;

        IsMoving = false;
        Moving?.Invoke(IsMoving);
    }
}