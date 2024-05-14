using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private readonly Quaternion _unitAngle = Quaternion.Euler(0, 270, 0);

    [SerializeField] private Transform _targetParent;
    [SerializeField] private Button _startButton;

    [Header("Config")]
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private List<Vector3> _positions;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var position in _positions)
        {
            var unit = Instantiate(_unitPrefab, position, _unitAngle, _transform);
            unit.Init(true, _targetParent, _startButton);
        }
    }
}