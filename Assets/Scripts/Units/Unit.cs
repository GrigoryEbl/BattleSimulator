using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour, IDamageable
{
    private readonly float _deathDelay = 2.5f;

    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;

    private RagdollHandler _ragdollHandler;
    private BehaviorTree _behaviorTree;
    private Transform _targetParent;
    private Transform _transform;
    private Button _startButton;
    private float _startYPosition;
    private bool _isEnemy;

    public int Health => _health;
    public int Price => _price;
    public bool IsEnemy => _isEnemy;
    public Transform TargetParent => _targetParent;
    protected Weapon UnitWeapon => _weapon;

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
        _weapon.SetBattleSide(isEnemy);
        _targetParent = targetParent;
        _startButton = startButton;
        _startButton.onClick.AddListener(StartBattle);
    }
    
    public void Fell()
    {        
        _ragdollHandler.TurnOn(true);
    }

    public void Die()
    {
        Fell();
        _transform.parent = null;
        _startButton.onClick.RemoveListener(StartBattle);
        Invoke(nameof(RemoveBody), _deathDelay);
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

    public void Hit(Vector3 force, Vector3 position)
    {
        _ragdollHandler.Hit(force, position);
    }

    protected void ResetWeapon()
    {
        _weapon = null;
    }

    private void RemoveBody()
    {
        _behaviorTree.enabled = false;
        _ragdollHandler.RemoveBody();
    }

    private void StartBattle()
    {
        _behaviorTree.enabled = true;
    }
}