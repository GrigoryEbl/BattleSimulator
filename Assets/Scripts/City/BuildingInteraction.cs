using System;
using UnityEngine;

internal class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;
    [SerializeField] private int _price;
    [SerializeField] private Canvas _priceView;

    private BoxCollider _triggerCollider;

    public int Price => _price;

    private void Awake()
    {
        _triggerCollider = GetComponent<BoxCollider>();
    }

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
        _triggerCollider.enabled = false;
        _priceView.gameObject.SetActive(false);
    }
}
