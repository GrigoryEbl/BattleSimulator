using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isEnemy;

    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;

    public int Price => _price;
    public bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>(); 
    }

    public void Die()
    {
        _animControlTest.DisabledAnimator();
        _ragdollHandler.Enable();
    }
    
    public void StandUp()
    {
        _animControlTest.EnabledAnimator();
        _ragdollHandler.Disable();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if( _health <= 0 )
        {
            _health = 0;
            Die();
        }
    }

    public void Attack()
    {
        _animControlTest.SetAttack();
    }

    public void SetIdle()
    {
        _animControlTest.SetIdle();
    }

    public void SetRun()
    {
        _animControlTest.SetRun();
    }
}
