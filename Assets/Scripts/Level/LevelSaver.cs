using UnityEngine;

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
        PlayerPrefs.Save();
    }

    private void SaveLevel()
    {
        int currentMap = PlayerPrefs.GetInt(GameSaver.CurrentMap);

        if (currentMap == _finalMap)        
            return;        

        if (_currentLevelNumber == _levelsCount)
        {
            PlayerPrefs.SetInt(GameSaver.CurrentLevel, _levelStep);
            PlayerPrefs.SetInt(GameSaver.CurrentMap, currentMap + _levelStep);
        }
        else
        {
            int level = PlayerPrefs.GetInt(GameSaver.CurrentLevel) + _levelStep;
            PlayerPrefs.SetInt(GameSaver.CurrentLevel, level);
        }
    }
}