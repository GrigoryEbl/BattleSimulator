using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitIconHandler : MonoBehaviour
{
   [SerializeField] private Image _image;

    private BuildingInteraction _buildingInteraction;

    private void Awake()
    {
        _buildingInteraction = GetComponentInParent<BuildingInteraction>();
    }

    private void OnEnable() => _buildingInteraction.BuildingUnlocked += Show;
    private void OnDisable () => _buildingInteraction.BuildingUnlocked -= Show;

    public void Show()
    {
        _image.color = Color.white;
    }
}