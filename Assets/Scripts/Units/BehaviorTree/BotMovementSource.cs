using UnityEngine;

public class BotMovementSource : MonoBehaviour, IMovementSource
{
    [SerializeField] private float _speed = 3f;

    private float _currentSpeed;

    public Vector3 MovementInput { get; set; }
    public float Speed => _currentSpeed;

    private void Awake()
    {
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        _currentSpeed = _speed;
    }

    public void DivideSpeed(float value)
    {
        _currentSpeed = _speed / value;
    }
}