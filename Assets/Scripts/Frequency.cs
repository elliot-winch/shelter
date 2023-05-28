using UnityEngine;

public class BoundedValueTopic : Topic<float>
{
    public float Min;
    public float Max;

    public override float Value 
    { 
        set => base.Value = Mathf.Clamp(value, Min, Max);
    }

    public float Scaled => Mathf.InverseLerp(Min, Max, Value);
}

public class Frequency : MonoBehaviour
{
    [SerializeField]
    private float m_min;
    [SerializeField]
    private float m_max;
    [SerializeField]
    private float m_startingFrequency;

    public BoundedValueTopic CurrentFrequency { get; } = new BoundedValueTopic();

    private void Awake()
    {
        CurrentFrequency.Min = m_min;
        CurrentFrequency.Max = m_max;
        CurrentFrequency.Value = m_startingFrequency;
    }

    //For use in the inspector
    public void SetFrequency(float frequency)
    {
        CurrentFrequency.Value = frequency;
    }

    //For use in the inspector
    public void MoveFrequencyBy(float amount)
    {
        CurrentFrequency.Value += amount;
    }
}
