using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<BuildingInteraction> BuildingReached;
    public event Action BuildingEscaped;

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
