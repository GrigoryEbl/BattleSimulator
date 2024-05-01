using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
            _unit.Attack();
    }
}
