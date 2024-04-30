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

        transform.LookAt(_target.Value);
        _direction.Value = Vector3.forward;

        return TaskStatus.Success;
    }
}
