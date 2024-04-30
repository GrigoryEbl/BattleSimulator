using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetTarget : Action
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        FindTarget();

        return _target.Value == null ? TaskStatus.Failure : TaskStatus.Success;
    }

    private void FindTarget()
    {
        float distance;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _unitsParent.childCount; i++)
        {
            distance = Vector3.Distance(_unitsParent.GetChild(i).position, transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                _target.Value = _unitsParent.GetChild(i);
            }
        }
    }
}