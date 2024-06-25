using BS.Wallets;
using TMPro;
using UnityEngine;

namespace BS.City.Mines
{
    [RequireComponent(typeof(Timer))]
    public class Mine : MonoBehaviour
    {
        [SerializeField] private int _chargedMoney;
        [SerializeField] private float _miningTime;
        [SerializeField] private TMP_Text _moneyView;

        private int _currentMoney;

        private Timer _timer;

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            _timer.TimeOver += CollectMoney;
        }

        private void Start()
        {
            StartMine();
        }

        private void OnDisable()
        {
            _timer.TimeOver -= CollectMoney;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerWallet wallet))
            {
                if (_currentMoney > 0)
                {
                    wallet.AddMoney(_currentMoney);
                    StartMine();
                }
            }
        }

        private void ChangeMoney(int value)
        {
            _currentMoney = value;
            _moneyView.text = value.ToString();
        }

        private void StartMine()
        {
            ChangeMoney(0);
            _timer.StartWork(_miningTime);
        }

        private void CollectMoney()
        {
            ChangeMoney(_chargedMoney);
        }
    }
}