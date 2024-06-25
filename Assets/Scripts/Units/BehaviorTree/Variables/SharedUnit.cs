using System;
using BehaviorDesigner.Runtime;
using BS.Units;

[Serializable]
public class SharedUnit : SharedVariable<Unit>
{
    public static implicit operator SharedUnit(Unit value)
    {
        return new SharedUnit { Value = value };
    }
}