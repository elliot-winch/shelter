using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceLoudness : MonoBehaviour
{
    private AudioSource m_Source;

    private AudioClip m_clip;
    private float[] m_samples;

    private void Awake()
    {
        m_Source = GetComponent<AudioSource>();
    }

    public float GetCurrentLoudness(float duration)
    {
        return GetLoudness(m_Source.time, duration);
    }

    public float GetLoudness(float startingTime, float duration)
    {
        UpdateSamples();

        if (m_clip != null)
        {
            return GetLoudness(TimeToSample(startingTime), TimeToSample(duration));
        }

        return 0f;
    }

    public float GetLoudness(int startingSample, int samples)
    {
        UpdateSamples();

        if (m_samples != null)
        {
            return CalculateLoudness(startingSample, samples);
        }

        return 0f;
    }

    private int TimeToSample(float time)
    {
        return Mathf.FloorToInt(time * m_clip.frequency * m_Source.clip.channels);
    }

    private float CalculateLoudness(int startingSample, int samples)
    {
        float loudness = 0f;
        int sampleCount = 0;

        
        for (int i = startingSample; i < startingSample + samples; i++)
        {
            if (i < m_samples.Length)
            {
                loudness += Mathf.Abs(m_samples[i]);
                sampleCount++;
            }
        }

        //Debug.Log($"Loundess: {loudness} Samples considered: {sampleCount}");

        if (sampleCount > 0)
        {
            loudness /= sampleCount;
        }
        

        //Debug.Log($"Scaled loudness: {loudness}");

        return loudness;
    }

    private void UpdateSamples()
    {
        if (m_clip != m_Source.clip)
        {
            m_clip = m_Source.clip;

            if (m_clip != null)
            {
                m_samples = LoadSamples();
            }
            else
            {
                m_samples = null;
            }
        }
    }

    private float[] LoadSamples()
    {
        float[] samples = new float[m_Source.clip.samples * m_Source.clip.channels];
        m_Source.clip.GetData(samples, 0);
        return samples;
    }
}
