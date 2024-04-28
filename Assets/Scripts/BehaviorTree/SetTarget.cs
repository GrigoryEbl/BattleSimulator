using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetTarget : Action
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_unitsParent.childCount > 0)
            _target.Value = _unitsParent.GetChild(0);

        return _target.Value == null ? TaskStatus.Failure : TaskStatus.Success;
    }
}
