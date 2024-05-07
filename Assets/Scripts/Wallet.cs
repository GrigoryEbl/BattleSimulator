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
    }

    public void AddMoney(int value)
    {
        _money += value;
        MoneyChanged?.Invoke(Money);
    }

    public void RemoveMoney(int price)
    {
        _money -= price;
        MoneyChanged?.Invoke(Money);
    }
}