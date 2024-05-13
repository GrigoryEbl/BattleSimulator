using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUnlocker : MonoBehaviour
{
    [SerializeField] private Transform _building;
    [SerializeField] private Transform _lockedBuilding;

    public void Unlock()
    {
        _lockedBuilding.gameObject.SetActive(false);
        _building.gameObject.SetActive(true);
    }
}
