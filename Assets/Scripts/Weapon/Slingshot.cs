using UnityEngine;

[RequireComponent(typeof(ProjectilesPool))]
public class Slingshot : Weapon
{
    private readonly float _range = 10f;
    private readonly float _minHeight = 1f;
    private readonly float _maxHeight = 3f;

    [SerializeField] private Transform _startPoint;

    private Thrower _thrower = new Thrower();
    private ProjectilesPool _pool;
    private float _currentHeight;

    private void Awake()
    {
        _pool = GetComponent<ProjectilesPool>();
        _pool.Initialize(IsEnemy);
    }

    public void Shoot(Vector3 targetPosition)
    {
        SetHeight(targetPosition);
        var velocity = _thrower.CalculateVelocityByHeight(_startPoint.position, targetPosition, _currentHeight);
        var bomb = _pool.Pull();
        bomb.gameObject.SetActive(true);
        bomb.Hurl(_startPoint, velocity);
    }

    private void SetHeight(Vector3 targetPosition)
    {
        float lerpFactor = Vector3.Distance(transform.position, targetPosition) / _range;

        _currentHeight = Mathf.Lerp(_minHeight, _maxHeight, lerpFactor);
    }
}