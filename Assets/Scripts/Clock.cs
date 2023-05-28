using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private float m_startTime;

    public Topic<float> Time { get; } = new Topic<float>();

    private void Awake()
    {
        ResetTime();
    }

    void Update()
    {
        Time.Value += UnityEngine.Time.deltaTime;
    }

    public void ResetTime () 
    { 
        Time.Value = m_startTime; 
    }
}
