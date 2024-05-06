using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private AnimControlTest _animator;

    private void Awake()
    {
        _animator = GetComponent<AnimControlTest>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _animator.SetAttack();
    }
}