using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class PoisonField : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private Timer _timerLifeTime;

    private void Awake()
    {
        _timerLifeTime = GetComponent<Timer>();
        StartCoroutine(_timerLifeTime.Work(_lifeTime));
    }

    private void OnEnable() => _timerLifeTime.TimeOver += DestroySelf;

    private void OnDisable() => _timerLifeTime.TimeOver -= DestroySelf;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))// && unit.TryGetComponent(out PoisonEffect poisonEffect) == false)
        {
            unit.gameObject.AddComponent<PoisonEffect>();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
