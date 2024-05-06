using UnityEngine;

public enum UnitAnimatorStates
{
    idle,
    run,
    gettingUp
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
        _animator.SetInteger(AnimatorNames.State, (int)state);
    }

    public void Attack()
    {
        _animator.SetTrigger(AnimatorNames.Attack);
    }

    public void TurnOnAnimator(bool value)
    {
        _animator.enabled = value;
    }
}