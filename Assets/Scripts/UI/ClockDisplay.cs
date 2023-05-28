using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro m_clockText;
    [SerializeField]
    private Clock m_clock;
    [SerializeField]
    private float m_startingSeconds;

    private void Awake()
    {
        m_clock.Time.Subscribe(SetClockText);
    }

    private void SetClockText(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds + m_startingSeconds);
        m_clockText.text = time.ToString("hh':'mm");
    }
}
