using UnityEngine;
using YG;

public class LevelSaver : MonoBehaviour
{
    private readonly int _levelStep = 1;

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
        if (_currentLevelNumber == _levelsCount)
        {
            YandexGame.savesData.CurrentLevel = _levelStep;
            YandexGame.savesData.CurrentMap = YandexGame.savesData.CurrentMap + _levelStep;
        }
        else
        {
            YandexGame.savesData.CurrentLevel = YandexGame.savesData.CurrentLevel + _levelStep;
        }

        _wallet.AddMoney(_moneyReward);
        YandexGame.SaveProgress();
    }
}