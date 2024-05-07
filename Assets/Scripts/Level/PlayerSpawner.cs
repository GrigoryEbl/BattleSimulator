using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    private readonly Quaternion _unitAngle = Quaternion.Euler(0, 90, 0);

    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _startButton;
    [SerializeField] private Transform _targetParent;

    private Unit _unitPrefab;
    private Transform _transform;
    private int _maxSpawnUnitCount;

    public event Action<int> UnitsCountChanged;

    public int MaxSpawnCount => _maxSpawnUnitCount;

    private void Awake()
    {
        _transform = transform;
    }

    public void Initialize(int maxSpawnUnitCount)
    {
        _maxSpawnUnitCount = maxSpawnUnitCount;   
    }

    public void Spawn(Vector3 position)
    {
        if (_unitPrefab == null)
            return;

        if (_transform.childCount < _maxSpawnUnitCount && _unitPrefab.Price <= _wallet.Money)
            SpawnUnit(position);
    }

    private void SpawnUnit(Vector3 position)
    {
        var unit = Instantiate(_unitPrefab, position, _unitAngle, _transform);
        unit.Init(false, _targetParent, _startButton);

        UnitsCountChanged?.Invoke(_transform.childCount);
        _wallet.RemoveMoney(_unitPrefab.Price);
    }

    public void SelectUnit(Unit unit)
    {
        _unitPrefab = unit;
    }

    public void Clean()
    {
        for (int i = 0; i < _transform.childCount; i++)        
            RemoveOneUnit(_transform.GetChild(i).GetComponent<Unit>());        

        UnitsCountChanged?.Invoke(0);
    }

    public void RemoveOneUnit(Unit unit)
    {
        _wallet.AddMoney(unit.Price);
        Destroy(unit.gameObject);
        UnitsCountChanged?.Invoke(_transform.childCount - 1);
    }
}