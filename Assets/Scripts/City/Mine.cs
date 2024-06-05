using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Timer))]
public class Mine : MonoBehaviour
{
    [SerializeField] private int _chargedMoney;
    [SerializeField] private float _time;
    

    private Wallet _mainWallet;
    private Timer _timer;

    public Wallet MainWallet => _mainWallet;


    private void Awake()
    {
        _mainWallet = GetComponent<Wallet>();
        _mainWallet.Initialize(0);
        _timer = GetComponent<Timer>();
        StartTimer();
    }

    private void OnEnable()
    {
        _timer.TimeOver += ChargeMoney;
    }

    private void OnDisable()
    {
        _timer.TimeOver -= ChargeMoney;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_mainWallet.Money > 0)
            {
                Pay(player);
                StartTimer();
            }
        }
    }

    private void ChargeMoney()
    {
        _mainWallet.AddMoney(_chargedMoney);
        print("Add money: " + _chargedMoney);
    }

    private void Pay(Player player)
    {
        player.Wallet.AddMoney(_mainWallet.Money);
        _mainWallet.RemoveMoney(_mainWallet.Money);
    }

    private void StartTimer()
    {
        StartCoroutine(_timer.Work(_time));
    }
}