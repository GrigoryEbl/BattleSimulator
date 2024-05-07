using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AttackAction : Action
{
    [SerializeField] private SharedAnimatorController _animatorController;
    [SerializeField] private SharedTransform _target;

    public override TaskStatus OnUpdate()
    {
        if (_target.Value == null)
            return TaskStatus.Failure;


        if (_target.Value.TryGetComponent(out Unit unit) && unit.Health > 0)
        {
            transform.LookAt(_target.Value);
            _animatorController.Value.Attack();
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}