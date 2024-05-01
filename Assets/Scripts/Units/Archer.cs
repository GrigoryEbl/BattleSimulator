using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    [SerializeField] private Bow _bow;
    [SerializeField] private Transform _target;

    public void Shoot()
    {
        _bow.Shoot();
    }

    public void SetDirectionArrow()
    {

    }
}
