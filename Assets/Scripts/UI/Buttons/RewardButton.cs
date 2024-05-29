using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class RewardButton : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private VideoAd _videoAd;
    [SerializeField] private int _rewardMoneyCount = 25;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(AddReward);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(AddReward);
    }

    private void AddReward()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _videoAd.Show(_button, _wallet.AddMoney, _rewardMoneyCount);
        gameObject.SetActive(false);
#else
        _wallet.AddMoney(_rewardMoneyCount);
        gameObject.SetActive(false);
#endif
    }
}