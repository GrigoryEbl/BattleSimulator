using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class BuildingInteractionView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _buttonPay;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textPrice;

    private void OnEnable()
    {
        _player.BuildingReached += Activate;
        _player.BuildingEscaped += Disable;
    }

    private void OnDisable()
    {
        _player.BuildingReached -= Activate;
        _player.BuildingEscaped -= Disable;
    }

    private void Activate(BuildingInteraction buildingInteraction)
    {
        _panel.SetActive(true);
        _textPrice.text = buildingInteraction.Price.ToString();
        _buttonPay.onClick.AddListener(delegate { buildingInteraction.Buy(_player.Wallet); });
        _buttonPay.onClick.AddListener(Disable);
    }

    private void Disable()
    {
        _panel.SetActive(false);
        _buttonPay.onClick.RemoveAllListeners();
    }
}