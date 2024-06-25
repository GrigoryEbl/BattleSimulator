using BS.StaticData;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    public bool IsAttack => _animator.GetCurrentAnimatorStateInfo(0).IsName(AnimatorStates.Attack.ToString());

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetState(AnimatorStates state)
    {
        if (_animator.GetInteger(StaticAnimatorData.State) != (int)state)
            _animator.SetInteger(StaticAnimatorData.State, (int)state);
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