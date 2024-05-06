using BehaviorDesigner.Runtime;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] private int _price;
    [SerializeField] private int _health;

    [Header("Temporary")]
    [SerializeField] private bool _isEnemy;
    [SerializeField] private Transform _targetParent;
    [SerializeField] private Button _startButton;

    private RagdollHandler _ragdollHandler;
    private BehaviorTree _behaviorTree;
    private Transform _transform;
    private float _startYPosition;

    public int Health => _health;
    public int Price => _price;
    public bool IsEnemy => _isEnemy;
    public Transform TargetParent => _targetParent;

    private void Awake()
    {
        _ragdollHandler = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _transform = transform;
        _startYPosition = _transform.position.y;
    }

    public void Init(bool isEnemy, Transform targetParent, Button startButton)
    {
        _isEnemy = isEnemy;
        _targetParent = targetParent;
        _startButton = startButton;
        _startButton.onClick.AddListener(StartBattle);
    }
    
    [ContextMenu("Fell")]
    public void Fell()
    {        
        _ragdollHandler.TurnOn(true);
    }

    public void Die()
    {
        Fell();
        _transform.parent = null;
        _behaviorTree.enabled = false;
        _startButton.onClick.RemoveListener(StartBattle);
    }

    public void ResetCurrentPosition()
    {
        _transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(_transform.forward, Vector3.up), Vector3.up);
        _transform.position = new Vector3(_transform.position.x, _startYPosition, _transform.position.z);
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

    private void StartBattle()
    {
        _behaviorTree.enabled = true;
    }
}