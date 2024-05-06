using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class TargetSetter : Action
{
    [SerializeField] private SharedUnit _unit;
    [SerializeField] private SharedTransform _target;

    private Transform _targetParent;

    public override void OnAwake()
    {
        _targetParent = _unit.Value.TargetParent;
    }

    public override TaskStatus OnUpdate()
    {
        FindTarget();

        return _target.Value == null ? TaskStatus.Failure : TaskStatus.Success;
    }

    private void FindTarget()
    {
        float distance;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _targetParent.childCount; i++)
        {
            distance = Vector3.Distance(_targetParent.GetChild(i).position, transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _target.Value = _targetParent.GetChild(i);
            }
        }
    }
}