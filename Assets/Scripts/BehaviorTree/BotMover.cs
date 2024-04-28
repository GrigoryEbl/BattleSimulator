using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BotInput))]
public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private BotInput _botInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _botInput = GetComponent<BotInput>();
    }

    private void Update()
    {
        _rigidbody.velocity = _botInput.MovementInput * _speed + Vector3.up * _rigidbody.velocity.y;
    }
}
