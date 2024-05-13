using System;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;
    [SerializeField] private int _price;

    public int Price => _price;

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
    }
}
