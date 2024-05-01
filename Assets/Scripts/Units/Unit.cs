using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;

    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;
    private BehaviorTree _behaviorTree;
    private BotInput _botInput;
    
    public int Price => _price;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _botInput = GetComponent<BotInput>();
    }

    public void Die()
    {
        _behaviorTree.enabled = false;
        _botInput.MovementInput = Vector3.zero;
        _animControlTest.DisabledAnimator();
        _ragdollHandler.Enable();
    }

    public void StandUp()
    {
        _animControlTest.EnabledAnimator();
        _ragdollHandler.Disable();
        _animControlTest.SetUp();
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
