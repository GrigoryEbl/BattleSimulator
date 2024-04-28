using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetDirection : Action
{
    [SerializeField] private SharedTransform _target;
    [SerializeField] private SharedVector3 _direction;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;

        _direction.Value = (_target.Value.position - transform.position).normalized;

        return TaskStatus.Success;
    }
}
