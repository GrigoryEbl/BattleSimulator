using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))
            unit.TakeDamage(_damage);
    }
}
