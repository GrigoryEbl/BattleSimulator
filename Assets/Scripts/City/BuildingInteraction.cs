using System;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;
    [SerializeField] private Transform[] _effects;
    [SerializeField] private Canvas _priceView;
    [SerializeField] private int _price;

    private SphereCollider _triggerCollider;

    public event Action BuildingUnlocked;

    public int Price => _price;

    private void Awake()
    {
        _triggerCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        GetLoad();
    }

    private void GetLoad()
    {
        if (GameSaver.HasBuilding(gameObject.name))
        {
            for (int i = 0; i < _effects.Length; i++)
                Destroy(_effects[i].gameObject);

            Unlock();
        }
    }

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
        _triggerCollider.enabled = false;
        _priceView.gameObject.SetActive(false);

        BuildingUnlocked?.Invoke();

        if (!GameSaver.HasBuilding(gameObject.name))
            GameSaver.SaveBuilding(gameObject.name);
    }

    public void Buy(Wallet wallet)
    {
        if (wallet.CanBuy(_price))
        {
            wallet.RemoveMoney(_price);
            Unlock();
        }
    }
}