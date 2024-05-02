using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckDistance : Conditional
{
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;

        float distance = Vector3.Distance(_target.Value.position, transform.position);

        return distance <= Random.Range(_minDistance, _maxDistance) ? TaskStatus.Success : TaskStatus.Failure;
    }
}
