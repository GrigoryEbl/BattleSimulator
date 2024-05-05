using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    private Unit _unit;
    private float _lifeTime = 10f;
    private float _startDelay = 2f;
    private int _damage = 1;
    private float _delay;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _delay = _startDelay;
        print(_unit.name + " Is poison");
    }

    private void Update()
    {
        _delay -= Time.deltaTime;
        _lifeTime -= Time.deltaTime;

        if(_lifeTime <= 0)
            enabled = false;

        if(_delay <= 0)
        {
            _unit.TakeDamage(_damage);
            print(_unit.name + "Health:" + _unit.Health);
            _delay = _startDelay;
        }
    }
}
