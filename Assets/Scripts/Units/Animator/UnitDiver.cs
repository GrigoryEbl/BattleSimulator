using System.Collections;
using UnityEngine;

public class UnitDiver : MonoBehaviour
{
    private readonly float _diveSpeed = 0.3f;
    private readonly float _diveTime = 5f;
    
    private float _timeCounter = 0f;

    private void Update()
    {
        if (_timeCounter <= 0)
            return;

        _timeCounter -= Time.deltaTime;
        Dive();
    }

    public void StartDive()
    {
        _timeCounter = _diveTime;
    }

    private void Dive()
    {
        transform.Translate(Vector3.down * _diveSpeed * Time.deltaTime);
    }
}