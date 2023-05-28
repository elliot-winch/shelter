using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveform : MonoBehaviour
{
    [SerializeField]
    private AudioSourceLoudness m_loudness;
    [SerializeField]
    private Transform m_barParent;
    [SerializeField]
    private float m_secondsPerBar;
    [SerializeField]
    private GameObject m_barPrefab;
    [SerializeField]
    private float m_leftPosition;
    [SerializeField]
    private float m_rightPosition;
    [SerializeField]
    private int m_maxBars;
    [SerializeField]
    private float m_maxBarSize;
    [SerializeField]
    private float m_minBarSize;
    [SerializeField]
    private float m_maxVolume;
    [SerializeField]
    private float m_minVolume;

    private Queue<GameObject> m_bars = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < m_maxBars; i++)
        {
            GameObject bar = SpawnBar();
            m_bars.Enqueue(bar);
        }

        MoveBars();
    }

    private void Update()
    {
        GameObject bar = SpawnBar();
        m_bars.Enqueue(bar);

        while (m_bars.Count > m_maxBars)
        {
            GameObject excessBar = m_bars.Dequeue();
            Destroy(excessBar);
        }

        MoveBars();
    }

    private GameObject SpawnBar()
    {
        GameObject bar = Instantiate(m_barPrefab);
        bar.transform.SetParent(m_barParent);
        bar.transform.localPosition = Vector3.zero;

        float loudness = m_loudness.GetCurrentLoudness(m_secondsPerBar);
        float scaledVolume = Mathf.InverseLerp(m_minVolume, m_maxVolume, loudness);
        float barSize = Mathf.Lerp(m_minBarSize, m_maxBarSize, scaledVolume);

        bar.transform.localScale = new Vector3()
        {
            x = bar.transform.localScale.x,
            y = barSize,
            z = bar.transform.localScale.z
        };

        return bar;
    }

    private void MoveBars()
    {
        GameObject[] bars = m_bars.ToArray();

        for(int i = 0; i < m_bars.Count; i++)
        {
            Vector3 pos = bars[i].transform.localPosition;
            float xPos = Mathf.Lerp(m_rightPosition, m_leftPosition, i / (float) m_maxBars);
            bars[i].transform.localPosition = new Vector3(xPos, pos.y, pos.z);
        }
    }
}
