using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Timer))]
public class Mine : MonoBehaviour
{
    [SerializeField] private int _chargedMoney;
    [SerializeField] private float _time;

    private int _currentMoney;
    private Timer _timer;


    private void Awake()
    {
        _timer = GetComponent<Timer>();
        StartCoroutine(_timer.Work(_time));
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
            if (_currentMoney > 0)
                player.Wallet.AddMoney(_currentMoney);
        }
    }

    private void ChargeMoney()
    {
        print("Add money: " + _chargedMoney);
        _currentMoney += _chargedMoney;
    }
}
