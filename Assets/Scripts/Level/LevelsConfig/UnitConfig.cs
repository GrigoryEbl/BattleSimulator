using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitConfig", menuName = "Levels/Create new UnitConfig", order = 51)]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private List<Vector3> _positions;

    public Unit UnitPrefab => _unitPrefab;
    public IReadOnlyList<Vector3> Positions => _positions;
}