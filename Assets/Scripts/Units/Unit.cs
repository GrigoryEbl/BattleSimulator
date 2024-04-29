using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private bool _isEnemy;

    [SerializeField] private Unit _target; //temporary
    
    private RagdollHandler _ragdollHandler;
    private AnimControlTest _animControlTest;
    private float _lastAttackTime = 1;
    private float _delay = 1;

    public int Price => _price;
    public bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _animControlTest = GetComponent<AnimControlTest>();
        _ragdollHandler = GetComponent<RagdollHandler>(); 
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _attackDistance)
        {
            if (_lastAttackTime <= 0)
            {
                Attack(_target);
                _lastAttackTime = _delay;
            }
        }
        else
            _animControlTest.SetIdle();
        
        _lastAttackTime -= Time.deltaTime;
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

    public void Attack(Unit target)
    {
        _animControlTest.SetAttack();
    }
}
