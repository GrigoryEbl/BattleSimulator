using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedRagdollHandler : SharedVariable<RagdollHandler>
{
    public static implicit operator SharedRagdollHandler(RagdollHandler value)
    {
        return new SharedRagdollHandler { Value = value };
    }
}