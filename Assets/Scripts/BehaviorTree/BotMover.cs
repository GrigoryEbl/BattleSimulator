using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BotMovementSource))]
public class BotMover : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private BotMovementSource _movementSource;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _movementSource = GetComponent<BotMovementSource>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        var horizontalVelocity = _rigidbody.velocity.y * Vector3.up;
        _rigidbody.velocity = _movementSource.MovementInput * _movementSource.Speed + horizontalVelocity;
    }

    private void Rotate()
    {
        if (_movementSource.MovementInput != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_movementSource.MovementInput, Vector3.up);
    }
}