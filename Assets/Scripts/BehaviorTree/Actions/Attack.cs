using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack : Action
{
    [SerializeField] private SharedUnit _unit;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value.TryGetComponent(out Unit unit))
        {
            _unit.Value.Attack();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
