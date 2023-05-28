using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private RadioSettings m_Radio;
    [SerializeField]
    private Frequency m_Frequency;
    [SerializeField]
    private AntennaPosition m_AntennaPosition;
    [SerializeField]
    private Clock m_Clock;
    [SerializeField]
    private MessageManager m_messageManager;

    private void Start()
    {
        m_Frequency.CurrentFrequency.Subscribe(UpdateMessageManagerFromRadio);
        m_AntennaPosition.XPosition.Subscribe(UpdateMessageManagerFromRadio);
        m_AntennaPosition.YPosition.Subscribe(UpdateMessageManagerFromRadio);
        m_Radio.SettingsMask.Subscribe(UpdateMessageManagerFromRadio);
        m_Clock.Time.Subscribe(UpdateMessageManagerFromRadio);

        //m_Radio.SettingsMask.Subscribe(m => Debug.Log(m));
        //m_Radio.Time.Subscribe(UpdateMessageManagerFromRadio);
    }

    private void UpdateMessageManagerFromRadio()
    {
        m_messageManager.CheckForMessage(m_Frequency.CurrentFrequency.Value,
            m_AntennaPosition.Position,
            m_Radio.SettingsMask.Value,
            m_Clock.Time.Value);
    }
}
