using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedMovementSource : SharedVariable<BotMovementSource>
{
    public static implicit operator SharedMovementSource(BotMovementSource value) => new SharedMovementSource { Value = value };
}