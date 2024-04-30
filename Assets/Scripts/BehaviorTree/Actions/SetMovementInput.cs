using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetMovementInput : Action
{
    [SerializeField] private SharedBotInput _selfBotInput;
    [SerializeField] private SharedVector3 _direction;
    [SerializeField] private SharedUnit _unit;

    public override TaskStatus OnUpdate()
    {
        _selfBotInput.Value.MovementInput = _direction.Value;

        if (_selfBotInput.Value.MovementInput == Vector3.zero)
            _unit.Value.SetIdle();
        else
            _unit.Value.SetRun();

        return TaskStatus.Success;
    }
}