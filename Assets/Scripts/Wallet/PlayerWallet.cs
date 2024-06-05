using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

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
        Initialize(YandexGame.savesData.PlayerMoney);

        Debug.Log(YandexGame.savesData.Score);
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
        YandexGame.savesData.Score += value;
        SaveMoney();

#if UNITY_WEBGL && !UNITY_EDITOR
        _leaderboardScoreSetter.SetPlayerScore(YandexGame.savesData.Score);
#endif
    }

    public override void RemoveMoney(int price)
    {
        base.RemoveMoney(price);
        SaveMoney();
    }

    private void SaveMoney()
    {
        YandexGame.savesData.PlayerMoney = Money;
        YandexGame.SaveProgress();
    }
}