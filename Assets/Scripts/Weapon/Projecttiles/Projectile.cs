using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Weapon))]
public class Projectile : MonoBehaviour
{
    private readonly float _pushDelay = 10f;

    private ProjectilesPool _pool;
    private Rigidbody _rigidbody;
    private Weapon _weapon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _weapon = GetComponent<Weapon>();
    }    

    public void Initialize(ProjectilesPool pool)
    {
        _pool = pool;
    }

    public void Hurl(Transform startPoint, Vector3 velocity, bool isEnemy)
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
        _rigidbody.velocity = velocity;
        _weapon.SetBattleSide(isEnemy);
        Invoke(nameof(Push), _pushDelay);
    }

    private void Push()
    {
        _pool.Push(this);
    }
}