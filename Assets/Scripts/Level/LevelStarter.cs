using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> _levelsConfigs;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += PrepareLevel;
    }

    private void Start()
    {
        PrepareLevel();//Убрать при билдинге
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= PrepareLevel;
    }

    private void Initialize(LevelConfig levelConfig)
    {
        _wallet.Initialize(levelConfig.LevelMoney);
        _enemySpawner.Initialize(levelConfig.UnitsConfig);
        _playerSpawner.Initialize(levelConfig.MaxSpawnUnitCount);
    }

    private LevelConfig GetCurrentLevel()
    {
        int levelNumber = Mathf.Min(YandexGame.savesData.CurrentLevel, _levelsConfigs.Count);

        return _levelsConfigs.FirstOrDefault(levelConfig => levelConfig.Number == levelNumber);
    }

    private void PrepareLevel()
    {
        var levelConfig = GetCurrentLevel();

        if (levelConfig == null)
            throw new ArgumentNullException(nameof(LevelConfig));

        Initialize(levelConfig);
        _enemySpawner.Spawn();
    }
}