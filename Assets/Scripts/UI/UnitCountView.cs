using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        ShowValue(0);
        _spawner.UnitsCountChanged += ShowValue;
    }
    private void OnDisable () => _spawner.UnitsCountChanged -= ShowValue;

    private void ShowValue(int value)
    {
        _text.text = $"{value} / {_spawner.MaxSpawnCount}";
    }
}
