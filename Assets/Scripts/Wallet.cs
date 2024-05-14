using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money = 1000;

    public event Action<int> MoneyChanged;

    public int Money => _money;

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