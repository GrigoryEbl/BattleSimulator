using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private Archer _archer;

    private void Awake()
    {
        _archer = GetComponent<Archer>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
            _archer.Attack();
    }
}
