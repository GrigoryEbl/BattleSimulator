using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        ShowMoney(_wallet.Money);
        _wallet.MoneyChanged += ShowMoney;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= ShowMoney;
    }

    private void ShowMoney(int value)
    {
        _text.text = value.ToString();
    }
}
