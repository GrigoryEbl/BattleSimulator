using UnityEngine;

public class Grenade : Projectile
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _delay;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _explosionEffect;

    private ParabolaController _parabolaController;
    private Timer _timer;

    private void Awake()
    {
        _parabolaController = GetComponent<ParabolaController>();
        _timer = GetComponent<Timer>();

        StartCoroutine(_timer.Work(_delay));
    }

    private void OnEnable() => _timer.TimeOver += Explode;

    private void OnDisable() => _timer.TimeOver -= Explode;

    public override void Init(Transform parabola, Transform parent)
    {
        _parabolaController.ParabolaRoot = parabola.gameObject;
    }

    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation,transform);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.TryGetComponent(out Rigidbody rigidbody) && nearbyObject.TryGetComponent(out Unit unit))
            {
                unit.Fell();
                unit.TakeDamage(_damage);
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,_radius);
    }
}