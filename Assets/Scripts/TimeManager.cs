using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int _time;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        _time = 500;
        InvokeRepeating(nameof(DecreaseAndUpdateTime), 0f, 1f);
    }

    private void DecreaseAndUpdateTime()
    {
        timeText.text = $"{_time}";
        _time--;
    }
}