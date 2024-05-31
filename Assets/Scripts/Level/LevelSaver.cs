using UnityEngine;
using YG;

public class LevelSaver : MonoBehaviour
{
    private readonly int _levelStep = 1;

    private int _currentLevelNumber;
    private int _levelsCount;
    
    public void Initialize(int levelsCount, int currentLevelNumber)
    {
        _levelsCount = levelsCount;
        _currentLevelNumber = currentLevelNumber;
    }

    public void FinishLevel()
    {
        if (_currentLevelNumber == _levelsCount)
        {
            YandexGame.savesData.CurrentLevel = _levelStep;
            YandexGame.savesData.CurrentMap = YandexGame.savesData.CurrentMap + _levelStep;
        }
        else
        {
            YandexGame.savesData.CurrentLevel = YandexGame.savesData.CurrentLevel + _levelStep;
        }

        YandexGame.SaveProgress();
    }
}