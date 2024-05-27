using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerr : MonoBehaviour
{
    public float Time { get; private set; }
    public float StartTime { get; private set; }

    public Action TimeOver;

    public IEnumerator Work(float startTime)
    {
        StartTime = startTime;
        Time = startTime;

        while (Time > 0)
        {
            Time -= UnityEngine.Time.deltaTime;

            yield return null;
        }

        TimeOver?.Invoke();
    }
}
