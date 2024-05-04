using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class StandUpFinisher : Action
{
    [SerializeField] private SharedRagdollHandler _ragdollHandler;

    public override TaskStatus OnUpdate()
    {
        _ragdollHandler.Value.TurnOnMainRigidbody(true);

        return TaskStatus.Success;
    }
}