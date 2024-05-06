using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private bool _isEnemy;

    private RagdollHandler _ragdollHandler;
    private BehaviorTree _behaviorTree;
    private float _startYposition;

    public int Health => _health;
    public int Price => _price;
    public bool IsEnemy => _isEnemy;

    private void Awake()
    {
        _ragdollHandler = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _startYposition = transform.position.y;
    }

    [ContextMenu("Fell")]
    public void Fell()
    {        
        _ragdollHandler.TurnOn(true);
    }

    public void Die()
    {
        Fell();
        _behaviorTree.enabled = false;
    }

    public void ResetCurrentPosition()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, Vector3.up), Vector3.up);
        transform.position = new Vector3(transform.position.x, _startYposition, transform.position.z);
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
}