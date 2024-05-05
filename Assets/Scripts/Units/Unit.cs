using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private bool _isEnemy;

    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;
    private BehaviorTree _behaviorTree;
    private float _startYposition;

    public int Health => _health;
    public int Price => _price;
    public bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _startYposition = transform.position.y;
    }

    public void Fell()
    {        
        _ragdollHandler.TurnOn(true);
        _animControlTest.DisabledAnimator();
    }

    public void Die()
    {
        Fell();
        _behaviorTree.enabled = false;
    }

    public void StandUp()
    {
        _ragdollHandler.TurnOn(false);
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, Vector3.up), Vector3.up);
        transform.position = new Vector3(transform.position.x, _startYposition, transform.position.z);
        _ragdollHandler.TurnOnMainRigidbody(false);
        _animControlTest.EnabledAnimator();
        _animControlTest.SetUp();
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