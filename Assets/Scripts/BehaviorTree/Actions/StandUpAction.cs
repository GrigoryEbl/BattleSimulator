using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class StandUpAction : Action
{
    [SerializeField] private SharedUnit _unit;

    public override TaskStatus OnUpdate()
    {
        _unit.Value.StandUp();

        return TaskStatus.Success;
    }
}