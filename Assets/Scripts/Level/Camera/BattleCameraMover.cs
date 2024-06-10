using UnityEngine;

[RequireComponent(typeof(CameraInput))]
public class BattleCameraMover : MonoBehaviour
{
    private readonly float _maxPositionX = 40f;
    private readonly float _minPositionX = -40;
    private readonly float _maxPositionZ = -25f;
    private readonly float _minPositionZ = -60f;
    private readonly float _maxPositionY = 9f;
    private readonly float _minPositionY = 3.5f;

    [SerializeField] private float _speed;

    private Transform _transform;
    private CameraInput _cameraInput;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _transform = transform;
        _cameraInput = GetComponent<CameraInput>();
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        _transform.Translate(_cameraInput.MoveInput * _speed * Time.deltaTime);

        ClampPosition();

        _transform.position = _currentPosition;
    }

    private void ClampPosition()
    {
        _currentPosition = _transform.position;
        _currentPosition.x = Mathf.Clamp(_currentPosition.x, _minPositionX, _maxPositionX);
        _currentPosition.y = Mathf.Clamp(_currentPosition.y, _minPositionY, _maxPositionY);
        _currentPosition.z = Mathf.Clamp(_currentPosition.z, _minPositionZ, _maxPositionZ);
    }
}