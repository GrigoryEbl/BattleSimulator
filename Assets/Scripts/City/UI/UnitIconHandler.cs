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

    private void Show()
    {
        _image.color = new Color(255, 255, 255, 255);
        print('*' + transform.parent.gameObject.name + ": UNLOCKED icon*");
    }
}