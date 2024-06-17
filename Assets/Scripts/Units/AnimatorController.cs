using UnityEngine;

public enum UnitAnimatorStates
{
    idle,
    run,
    Attack
};

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    public bool IsAttack => _animator.GetCurrentAnimatorStateInfo(0).IsName(UnitAnimatorStates.Attack.ToString());

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetState(UnitAnimatorStates state)
    {
        if (_animator.GetInteger(AnimatorNames.State) != (int)state)
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