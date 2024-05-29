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
        int minutes = Mathf.FloorToInt(_timer.Time / 60f);
        int seconds = Mathf.FloorToInt(_timer.Time % 60f);

        if (_timer.Time > 0)
            _text.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        else
            _text.text = "00:00";
    }
}
