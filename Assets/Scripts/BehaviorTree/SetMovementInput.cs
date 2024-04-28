using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetMovementInput : Action
{
    [SerializeField] private SharedBotInput _selfBotInput;
    [SerializeField] private SharedVector3 _direction;

    public override TaskStatus OnUpdate()
    {
        _selfBotInput.Value.MovementInput = _direction.Value;
        return TaskStatus.Success;
    }
}