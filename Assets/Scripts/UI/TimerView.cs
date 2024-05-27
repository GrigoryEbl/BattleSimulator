using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Mine _mine;
    
    private Timerr _timer;

    private void Awake()
    {
        _timer = _mine.GetComponent<Timerr>();
    }

    private void Update()
    {
        _text.text = _timer.Time.ToString("F0");
    }
}
