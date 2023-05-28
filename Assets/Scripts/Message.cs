using System;
using UnityEngine;

[Serializable]
public class Message
{
    public AudioClip AudioClip;
    public float Frequency;
    public Vector2 AntennaPosition;
    public int SettingsMask;
    public float StartTime;
    public bool Repeat;

    public override string ToString()
    {
        return AudioClip != null ? AudioClip.name : "Blank Message";
    }
}
