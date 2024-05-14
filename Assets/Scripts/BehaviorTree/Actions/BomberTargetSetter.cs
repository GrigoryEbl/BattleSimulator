using System;

public class BomberTargetSetter : TargetSetter
{
    private Bomber _bomber;

    public override void OnStart()
    {
        _bomber = Soldier as Bomber;

        if (_bomber == null)
            throw new ArgumentNullException(nameof(Bomber));
    }

    protected override void FindTarget()
    {
        base.FindTarget();
        _bomber.SetTarget(Target);
    }
}