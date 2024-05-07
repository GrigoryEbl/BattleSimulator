using System;
using UnityEngine;

[RequireComponent(typeof(LevelsPool))]
public class LevelStarter : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private LevelsPool _levelsPool;
    private LevelConfig _levelConfig;

    private void Awake()
    {
        _levelsPool = GetComponent<LevelsPool>();

        FindLevelConfig();
        Initialize();
    }

    private void Start()
    {
        _enemySpawner.Spawn();
    }

    private void Initialize()
    {
        _wallet.Initialize(_levelConfig.Money);
        _enemySpawner.Initialize(_levelConfig.UnitsConfig);
        _playerSpawner.Initialize(_levelConfig.MaxSpawnUnitCount);
    }

    private void FindLevelConfig()
    {
        _levelConfig = _levelsPool.GetCurrentLevel();

        if (_levelConfig == null)
            throw new ArgumentNullException(nameof(LevelConfig));
    }
}