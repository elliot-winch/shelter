using TMPro;
using UnityEngine;

public class AntennaPositionDisplay : MonoBehaviour
{
    [SerializeField]
    private AntennaPosition m_antennaPositon;
    [SerializeField]
    private TextMeshPro m_text;

    private void Start()
    {
        m_antennaPositon.XPosition.Subscribe(SetText);
        m_antennaPositon.YPosition.Subscribe(SetText);
    }

    private void SetText()
    {
        m_text.text = $"{m_antennaPositon.XPosition.Value},{m_antennaPositon.YPosition.Value}";
    }
}
