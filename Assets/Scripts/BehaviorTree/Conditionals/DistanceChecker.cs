using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class DistanceChecker : Conditional
{
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private SharedTransform _target;

    private float _range;

    public override void OnAwake()
    {
        _range = Random.Range(_minDistance, _maxDistance);
    }

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;

        float distance = Vector3.Distance(_target.Value.position, transform.position);

        return distance <= _range ? TaskStatus.Success : TaskStatus.Failure;
    }
}