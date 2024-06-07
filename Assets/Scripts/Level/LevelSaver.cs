using UnityEngine;
using YG;

public class LevelSaver : MonoBehaviour
{
    private readonly int _levelStep = 1;
    private readonly int _finalMap = 8;

    [SerializeField] private PlayerWallet _wallet;

    private int _currentLevelNumber;
    private int _levelsCount;
    private int _moneyReward;
    
    public void Initialize(int levelsCount, int currentLevelNumber, int moneyReward)
    {
        _levelsCount = levelsCount;
        _currentLevelNumber = currentLevelNumber;
        _moneyReward = moneyReward;
    }

    public void FinishLevel()
    {
        SaveLevel();

        _wallet.AddMoney(_moneyReward);
        YandexGame.SaveProgress();
    }

    private void SaveLevel()
    {
        int currentMap = YandexGame.savesData.CurrentMap;

        if (currentMap == _finalMap)        
            return;        

        if (_currentLevelNumber == _levelsCount)
        {
            YandexGame.savesData.CurrentLevel = _levelStep;
            YandexGame.savesData.CurrentMap = currentMap + _levelStep;
        }
        else
        {
            YandexGame.savesData.CurrentLevel = YandexGame.savesData.CurrentLevel + _levelStep;
        }
    }
}