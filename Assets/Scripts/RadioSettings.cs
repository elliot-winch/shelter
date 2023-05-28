using UnityEngine;

public class RadioSettings : MonoBehaviour
{
    public Topic<int> SettingsMask { get; } = new Topic<int>();

    public void ToggleSetting(int index)
    {
        SetSetting(index, IsEnabled(index) == false);
    }

    public void SetSetting(int index, bool enabled)
    {
        if (enabled)
        {
            SettingsMask.Value |= 1 << index;
        }
        else
        {
            SettingsMask.Value &= ~(1 << index);
        }
    }

    public bool IsEnabled(int index)
    {
        return (SettingsMask.Value >> index & 1) == 1;
    }
}
