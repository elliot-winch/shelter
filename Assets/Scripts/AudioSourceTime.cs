using UnityEngine;

/*
/// <summary>
/// AudioSource.time is not reliable for compressed audio
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioSourceTime : MonoBehaviour
{
    public float CurrentTime { get; private set; }

    private AudioSource m_audioSource;
    private AudioClip m_clip;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(m_audioSource.clip != m_clip)
        {
            m_clip = m_audioSource.clip;
            CurrentTime = 0;
        }

        if (m_audioSource.isPlaying)
        {
            CurrentTime += Time.deltaTime;
        }
    }
}
*/
