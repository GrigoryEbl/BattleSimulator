using UnityEngine;

[RequireComponent(typeof(Unit))]
public class MoundHandler : MonoBehaviour
{
    private readonly float _delay = 7f;

    private float _delayCounter;
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        if (_delayCounter > 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Fell()
    {
        if (_delayCounter > 0)
            return;

        _unit.Fell();
        _delayCounter = _delay;
    }
}