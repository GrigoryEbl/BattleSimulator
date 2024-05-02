using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private bool _isEnemy;
    [SerializeField] private Collider _hitBox;

    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;
    private BehaviorTree _behaviorTree;
    private Rigidbody _rigidbody;
    private BotMover _botMover;

    public int Price => _price;
    public bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _rigidbody = GetComponent<Rigidbody>();
        _botMover = GetComponent<BotMover>();
    }

    public void Fell()
    {
        TurnOnMove(false);
        _animControlTest.DisabledAnimator();
        _ragdollHandler.Enable();
    }

    public void Die()
    {
        Fell();
    }

    public void StandUp()
    {
        _animControlTest.EnabledAnimator();
        _ragdollHandler.Disable();
        _animControlTest.SetUp();
    }

    public void TurnOnMove(bool value)
    {
        _behaviorTree.enabled = value;
        _rigidbody.isKinematic = !value;
        _botMover.enabled = value;
        _hitBox.enabled = value;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
            return;

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
