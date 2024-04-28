using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private int _maxSpawnCount = 10;
    private Unit _unitPrefab;
    private Transform _transform;

    public event Action<int> UnitsCountChanged;

    public int MaxSpawnCount => _maxSpawnCount;

    private void Awake()
    {
        _transform = transform;
    }

    public void Spawn(Vector3 position)
    {
        if (_unitPrefab == null)
            return;

        if (_transform.childCount < _maxSpawnCount && _unitPrefab.Price <= _wallet.Money)
        {
            Instantiate(_unitPrefab, position, Quaternion.identity, _transform);
            UnitsCountChanged?.Invoke(_transform.childCount);
            _wallet.RemoveMoney(_unitPrefab.Price);
        }
    }

    public void SelectUnit(Unit unit)
    {
        _unitPrefab = unit;
        print("Unit selected");
    }

    public void Clean()
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            RemoveOneUnit(_transform.GetChild(i).GetComponent<Unit>());
        }

        UnitsCountChanged?.Invoke(0);
    }

    public void RemoveOneUnit(Unit unit)
    {
        _wallet.AddMoney(unit.Price);
        Destroy(unit.gameObject);
        UnitsCountChanged?.Invoke(_transform.childCount - 1);
    }
}
