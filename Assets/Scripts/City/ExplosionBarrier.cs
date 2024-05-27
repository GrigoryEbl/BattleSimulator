using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrier : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _destructible;
    [SerializeField] private GameObject _dinamite;

    public void Explode()
    {
        _explosionEffect.SetActive(true);
        _destructible.SetActive(false);
        _dinamite.SetActive(false);
    }
}
