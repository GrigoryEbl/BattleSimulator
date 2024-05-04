using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musketeer : Unit
{
    [SerializeField] private Musket _musket;
    [SerializeField] private Transform _target;

   public void Shoot()
    {
        _musket.RaycastShoot( _target.position);
    }
}
