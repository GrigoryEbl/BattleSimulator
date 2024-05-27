using System;
using UnityEngine;
using YG;

internal class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;
    [SerializeField] private int _price;
    [SerializeField] private Canvas _priceView;

    private SphereCollider _triggerCollider;

    public int Price => _price;

    private void Awake()
    {
        _triggerCollider = GetComponent<SphereCollider>();
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GetLoad()
    {
        if (YandexGame.savesData.OpenedBuildings.Contains(gameObject.name))
            Unlock();
    }

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
        _triggerCollider.enabled = false;
        _priceView.gameObject.SetActive(false);

        if (YandexGame.savesData.OpenedBuildings.Contains(gameObject.name) == false)
            SaveData();
    }

    private void SaveData()
    {
        YandexGame.savesData.OpenedBuildings.Add(gameObject.name);
        YandexGame.SaveProgress();
    }
}
