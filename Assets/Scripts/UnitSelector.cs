using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;
    
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    public void SetUnit()
    {
        _spawner.SelectUnit(_unitPrefab);
    }
}
