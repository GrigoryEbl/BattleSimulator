using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BotInput))]
public class BotMover : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private BotInput _botInput;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _botInput = GetComponent<BotInput>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        var horizontalVelocity = _rigidbody.velocity.y * Vector3.up;
        _rigidbody.velocity = _botInput.MovementInput * _botInput.Speed + horizontalVelocity;
    }

    private void Rotate()
    {
        if (_botInput.MovementInput != Vector3.zero)
            _transform.rotation = Quaternion.LookRotation(_botInput.MovementInput, Vector3.up);
    }
}
