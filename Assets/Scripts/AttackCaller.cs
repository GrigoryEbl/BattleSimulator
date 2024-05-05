using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    private Musketeer _musketeer;

    private void Awake()
    {
        _musketeer = GetComponent<Musketeer>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            _musketeer.Attack();
    }
}
