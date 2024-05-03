using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private �rossbowman _crossbowman;

    private void Awake()
    {
        _crossbowman = GetComponent<�rossbowman>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _crossbowman.Attack();
    }
}
