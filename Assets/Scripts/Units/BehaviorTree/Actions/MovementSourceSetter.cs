using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MovementSourceSetter : Action
{
    [SerializeField] private SharedMovementSource _movementSource;
    [SerializeField] private SharedVector3 _direction;

    public override TaskStatus OnUpdate()
    {
        _movementSource.Value.MovementInput = _direction.Value;

        return TaskStatus.Success;
    }
}