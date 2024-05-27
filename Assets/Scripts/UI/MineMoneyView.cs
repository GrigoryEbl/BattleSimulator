using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MineMoneyView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
       _wallet.MoneyChanged += ShowMoney;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= ShowMoney;
    }

    private void ShowMoney(int money)
    {
        _text.text = money.ToString();
    }
}
