using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedAnimatorController : SharedVariable<AnimatorController>
{
    public static implicit operator SharedAnimatorController(AnimatorController value)
    {
        return new SharedAnimatorController { Value = value };
    }
}