using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class FellHandler : MonoBehaviour
{
    private readonly WaitForSeconds _fellingTime = new WaitForSeconds(1.5f);
    private readonly WaitForSeconds _standUpTime = new WaitForSeconds(2.7f);
    private readonly float _delay = 6f;

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

    public void StartFell()
    {
        if (_delayCounter > 0)
            return;

        StartCoroutine(Fell());
    }

    private IEnumerator Fell()
    {
        _delayCounter = _delay;
        _unit.Fell();
        yield return _fellingTime;
        _unit.StandUp();
        yield return _standUpTime;
        _unit.TurnOnMove(true);
    }
}
