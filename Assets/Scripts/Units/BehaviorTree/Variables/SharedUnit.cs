using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedUnit : SharedVariable<Unit>
{
    public static implicit operator SharedUnit(Unit value)
    {
        return new SharedUnit { Value = value };
    }
}