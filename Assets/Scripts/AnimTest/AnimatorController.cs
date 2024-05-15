using UnityEngine;

public enum UnitAnimatorStates
{
    idle,
    run
}

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetState(UnitAnimatorStates state)
    {
        if (_animator.GetInteger(AnimatorNames.State) == (int)state)        
            return;        

        _animator.SetInteger(AnimatorNames.State, (int)state);
    }

    public void SetTrigger(int name)
    {
        _animator.SetTrigger(name);
    }

    public void TurnOnAnimator(bool value)
    {
        _animator.enabled = value;
    }
}