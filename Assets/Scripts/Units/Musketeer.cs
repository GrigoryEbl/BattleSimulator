using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musketeer : MonoBehaviour
{
    [SerializeField] private Musket _musket;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _target;

   public void Shoot()
    {
        _musket.RaycastShoot(_startPoint.position, _target.position);
    }
}
