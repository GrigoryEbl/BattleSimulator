using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class RagdollChecker : Conditional
{
    [SerializeField] private SharedRagdollHandler _ragdoll;

    public override TaskStatus OnUpdate()
    {
        return _ragdoll.Value.IsEnable ? TaskStatus.Success : TaskStatus.Failure;
    }
}