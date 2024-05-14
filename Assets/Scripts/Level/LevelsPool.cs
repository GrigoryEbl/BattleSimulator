using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsPool : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private List<LevelConfig> _levelConfig;

    public LevelConfig GetCurrentLevel()
    {
        return _levelConfig.FirstOrDefault(levelConfig => levelConfig.Number == _levelNumber);
    }
}