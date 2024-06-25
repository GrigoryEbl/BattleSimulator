using BS.StaticData;
using BS.Units;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BotMovementSource))]
[RequireComponent(typeof(AnimatorController))]
public class BotMover : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private AnimatorController _animatorController;
    private IMovementSource _movementSource;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _movementSource = GetComponent<BotMovementSource>();
        _animatorController = GetComponent<AnimatorController>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = _animatorController.IsAttack ? Vector3.zero : _movementSource.Direction;

        var horizontalVelocity = _rigidbody.velocity.y * Vector3.up;
        _rigidbody.velocity = direction * _movementSource.Speed + horizontalVelocity;

        var state = direction == Vector3.zero ? AnimatorStates.idle : AnimatorStates.run;
        _animatorController.SetState(state);
    }

    private void Rotate()
    {
        if (_movementSource.Direction != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_movementSource.Direction, Vector3.up);
    }
}