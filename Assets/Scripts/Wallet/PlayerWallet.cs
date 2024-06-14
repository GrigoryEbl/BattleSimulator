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
        Initialize(GameSaver.Money);
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
        GameSaver.SetMoney(Money);
    }

    private void SetScore(int addedValue)
    {
        GameSaver.SetScore(addedValue);

#if UNITY_WEBGL && !UNITY_EDITOR
        _leaderboardScoreSetter.SetPlayerScore(GameSaver.Score);
#endif
    }

    public override void RemoveMoney(int price)
    {
        base.RemoveMoney(price);

        GameSaver.SetMoney(Money);
    }
}