using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeleeWeapon))]
public class NewProjectile : MonoBehaviour
{
    private readonly float _pushDelay = 10f;

    private ProjectilesPool _pool;
    private Rigidbody _rigidbody;
    private MeleeWeapon _weapon;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _weapon = GetComponent<MeleeWeapon>();
    }    

    public void Initialize(ProjectilesPool pool)
    {
        _pool = pool;
    }

    public void Hurl(Transform startPosition, float force, bool isEnemy)
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
        _rigidbody.velocity = startPosition.forward * force;
        _weapon.SetBattleSide(isEnemy);
        Invoke(nameof(Push), _pushDelay);
    }

    private void Push()
    {
        _pool.Push(this);
    }
}