using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimControlTest : MonoBehaviour
{
    private Animator _animator;
    private States State
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAttack()
    {
        State = States.attack;
    }
    public void SetRun()
    {
        State = States.run;
    }
    public void SetIdle()
    {
        State = States.idle;
    }
}

public enum States
{
    idle,
    run,
    attack
}
