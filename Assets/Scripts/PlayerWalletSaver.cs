using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlayerWalletSaver : Wallet
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _wallet.AddMoney(150);
        }
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetLoad;
        _wallet.MoneyChanged += ChangeMoney;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetLoad;
        _wallet.MoneyChanged -= ChangeMoney;
    }

    private void ChangeMoney(int value)
    {
        Save();
    }

    private void Save()
    {
        YandexGame.savesData.PlayerMoney = _wallet.Money;
        YandexGame.SaveProgress();
    }

    private void GetLoad()
    {
       _wallet.Initialize(YandexGame.savesData.PlayerMoney);
    }
}
