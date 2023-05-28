using UnityEngine;

public class FrequencyNeedle : MonoBehaviour
{
    [SerializeField]
    private Frequency m_frequency;
    [SerializeField]
    private Transform m_needle;
    [SerializeField]
    private float m_needleMin;
    [SerializeField]
    private float m_needleMax;

    private void Start()
    {
        m_frequency.CurrentFrequency.Subscribe(MoveNeedle);
    }

    private void MoveNeedle()
    {
        //float xPos = Mathf.Lerp(m_minPosition, m_maxPosition, m_frequency.CurrentFrequency.Scaled);
        //m_needle.localPosition = new Vector3(xPos, m_needle.localPosition.y, m_needle.localPosition.z);

        float yRotation = Mathf.Lerp(m_needleMin, m_needleMax, m_frequency.CurrentFrequency.Scaled);
        m_needle.localRotation = Quaternion.Euler(m_needle.localRotation.x, yRotation, m_needle.localRotation.z);
    }
}
