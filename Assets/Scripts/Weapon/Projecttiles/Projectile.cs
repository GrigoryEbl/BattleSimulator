using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    private readonly float _pushDelay = 6f;

    private ProjectilesPool _pool;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private bool _isEnemy;

    protected bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Initialize(ProjectilesPool pool, bool isEnemy)
    {
        _pool = pool;
        _isEnemy = isEnemy;
        _transform.SetParent(_pool.transform);
    }

    public void Hurl(Transform startPoint, Vector3 velocity)
    {
        _transform.position = startPoint.position;
        _transform.rotation = startPoint.rotation;
        _rigidbody.velocity = velocity;
        Invoke(nameof(Push), _pushDelay);
    }

    protected void Push()
    {
        _pool.Push(this);
    }
}