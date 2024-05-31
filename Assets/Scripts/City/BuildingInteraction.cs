using System;
using UnityEngine;
using YG;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;
    [SerializeField] private int _price;
    [SerializeField] private Canvas _priceView;
    [SerializeField] private Transform[] _effects;

    private SphereCollider _triggerCollider;

    public event Action BuildingUnlocked;

    public int Price => _price;

    private void Awake()
    {
        _triggerCollider = GetComponent<SphereCollider>();

        GetLoad();
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.savesData.OpenedBuildings.Contains(gameObject.name))
        {
            Unlock();

            for (int i = 0; i < _effects.Length; i++)
            {
                Destroy(_effects[i].gameObject);
            }
        }
    }

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
        _triggerCollider.enabled = false;
        _priceView.gameObject.SetActive(false);
        BuildingUnlocked?.Invoke();

        if (YandexGame.savesData.OpenedBuildings.Contains(gameObject.name) == false)
            SaveData();
    }

    public void Buy(Wallet wallet)
    {
        if (wallet.CanBuy(_price))
        {
            wallet.RemoveMoney(_price);
            Unlock();
        }
    }

    private void SaveData()
    {
        YandexGame.savesData.OpenedBuildings.Add(gameObject.name);
        YandexGame.SaveProgress();
    }
}
