using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Movement _movement;
    private AnimatorController _animatorController;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _animatorController = GetComponent<AnimatorController>();
    }

    private void OnEnable()
    {
        _movement.Moving += SetState;
    }

    private void OnDisable()
    {

        _movement.Moving -= SetState;
    }

    private void SetState(bool isMoving)
    {
        if (isMoving)
        {
            _animatorController. SetState(UnitAnimatorStates.run);
        }
        else
        {
            _animatorController. SetState(UnitAnimatorStates.idle);
        }

    }
}
