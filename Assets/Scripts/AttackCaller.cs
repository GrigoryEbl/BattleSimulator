using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private Ñrossbowman _crossbowman;

    private void Awake()
    {
        _crossbowman = GetComponent<Ñrossbowman>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _crossbowman.Attack();
    }
}
