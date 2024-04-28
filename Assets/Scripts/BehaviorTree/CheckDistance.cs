using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckDistance : Conditional
{
    [SerializeField] private float _distance;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;

        return Vector3.Distance(_target.Value.position, transform.position) <= _distance ? TaskStatus.Success : TaskStatus.Failure;
    }
}
