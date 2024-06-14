using UnityEngine;

[RequireComponent(typeof(YandexLeaderboardScoreSetter))]
public class PlayerWallet : Wallet
{
    private YandexLeaderboardScoreSetter _leaderboardScoreSetter;

    private void Awake()
    {
        _leaderboardScoreSetter = GetComponent<YandexLeaderboardScoreSetter>();        
    }

    private void Start()
    {
        Initialize(PlayerPrefs.GetInt(GameSaver.Money));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))   //Delete
        {
            AddMoney(150);
        }
    }

    public override void AddMoney(int value)
    {
        base.AddMoney(value);

        SetScore(value);
        SaveMoney();
    }

    private void SetScore(int addedValue)
    {
        int score = PlayerPrefs.GetInt(GameSaver.Score) + addedValue;

        PlayerPrefs.SetInt(GameSaver.Score, score);
        PlayerPrefs.Save();

#if UNITY_WEBGL && !UNITY_EDITOR
        _leaderboardScoreSetter.SetPlayerScore(score);
#endif
    }

    public override void RemoveMoney(int price)
    {
        base.RemoveMoney(price);
        SaveMoney();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt(GameSaver.Money, Money);
        PlayerPrefs.Save();
    }
}