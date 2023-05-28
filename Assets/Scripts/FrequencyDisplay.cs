using TMPro;
using UnityEngine;


public class FrequencyDisplay : MonoBehaviour
{
    [SerializeField]
    private Frequency m_frequency;
    [SerializeField]
    private TextMeshPro m_text;

    private void Start()
    {
        m_frequency.CurrentFrequency.Subscribe(SetText);
    }

    private void SetText(float frequency)
    {
        m_text.text = $"{Mathf.FloorToInt(frequency)} QM";
    }
}
