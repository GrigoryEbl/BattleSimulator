using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<BuildingInteraction> BuildingReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BuildingInteraction buildingInteraction))
        {
            BuildingReached?.Invoke(buildingInteraction);
        }
    }
}
