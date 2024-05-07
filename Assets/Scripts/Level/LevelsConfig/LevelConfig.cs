using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create new Level", order = 51)]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private int _money;
    [SerializeField] private int _maxSpawnUnitCount;
    [SerializeField] private List<UnitConfig> _unitsConfig;

    public int Number => _number;
    public int Money => _money;
    public int MaxSpawnUnitCount => _maxSpawnUnitCount;
    public IReadOnlyList<UnitConfig> UnitsConfig => _unitsConfig;
}