using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackAction : Action
{
    [SerializeField] private SharedUnit _unit;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;


        if (_target.Value.TryGetComponent(out Unit unit))
        {
            transform.LookAt(unit.transform);
            _unit.Value.Attack();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}