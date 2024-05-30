using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public event Action<int> MoneyChanged;

    public int Money => _money;

    public void Initialize(int money)
    {
        _money = money;
        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(_money);
    }

    public void RemoveMoney(int price)
    {
        if (_money >= price)
        {
            _money -= price;
            MoneyChanged?.Invoke(_money);
        }
        else
        {
            print("Недостаточно денег");
        }
    }
}