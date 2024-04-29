using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    
    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;
    
    public int Price => _price;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>();
    }

    public void Kill()
    {
        _animControlTest.DisabledAnimator();
        _ragdollHandler.Enable();
    }
    
    public void StandUp()
    {
        _animControlTest.EnabledAnimator();
        _ragdollHandler.Disable();
    }

    public void TakeDamage(Vector3 force, Vector3 hitpoint)
    {
        Kill();
        _ragdollHandler.Hit(force, hitpoint);
    }
}
