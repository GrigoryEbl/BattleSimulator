using System;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
internal class Player : MonoBehaviour
{
    public event Action<BuildingInteraction> BuildingReached;
    public event Action BuildingEscaped;

    private Wallet _wallet;

    public Wallet Wallet => _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BuildingInteraction buildingInteraction))
        {
            BuildingReached?.Invoke(buildingInteraction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BuildingInteraction buildingInteraction))
        {
            BuildingEscaped?.Invoke();
        }
    }
}
