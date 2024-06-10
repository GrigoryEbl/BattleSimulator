using BehaviorDesigner.Runtime;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class MoundHandler : MonoBehaviour
{
    private readonly float _delay = 10f;

    private float _delayCounter;
    private Unit _unit;
    private BehaviorTree _behaviorTree;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _behaviorTree = GetComponent<BehaviorTree>();
    }

    private void Update()
    {
        if (_delayCounter > 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Fell()
    {
        if (_delayCounter > 0 || _behaviorTree.enabled == false)
            return;

        _unit.Fell();
        _delayCounter = _delay;
    }
}