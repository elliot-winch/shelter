using UnityEngine;

public class RadioSettingsButton : MonoBehaviour
{
    [SerializeField]
    private RadioSettings m_settings;
    [SerializeField]
    private int m_index;
    [SerializeField]
    private GameObject m_enabled;
    [SerializeField]
    private GameObject m_disabled;

    private void Start()
    {
        m_settings.SettingsMask.Subscribe(SetObjectsEnabled);
    }

    private void SetObjectsEnabled()
    {
        bool enabled = m_settings.IsEnabled(m_index);
        m_enabled.SetActive(enabled);  
        m_disabled.SetActive(enabled == false);
    }
}
