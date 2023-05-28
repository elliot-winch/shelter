using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_source;
    [SerializeField]
    private Message[] m_messages;
    [SerializeField]
    private float m_frequencyRange;
    [SerializeField]
    private float m_antennaRange;
    [SerializeField]
    private float m_timeBuffer = 0.05f;

    private Message m_currentMessage;

    private void Update()
    {
        if (m_source.isPlaying == false)
        {
            SetCurrentMessage(null);
        }
    }

    public void CheckForMessage(float frequency, Vector2 antennaPosition, int settingsMask, float time)
    {
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.AppendLine($"Checking for message with frequency {frequency}, antenna position {antennaPosition}, settingsMask {Convert.ToString(settingsMask, 2)}, time {time}");

        bool messageFound = false;

        foreach(Message message in m_messages)
        {
            float freqDistance = Mathf.Abs(frequency - message.Frequency);
            float antennaDistance = Vector2.Distance(antennaPosition, message.AntennaPosition);
            int settingsMatch = settingsMask ^ message.SettingsMask;
            float messageTime = time - message.StartTime;

            if (message.Repeat)
            {
                messageTime = Mathf.Max(0f, messageTime % message.AudioClip.length);
            }

            bool willPlay = freqDistance <= m_frequencyRange //frequency correct
                && antennaDistance <= m_antennaRange         //antenna position correct
                && settingsMatch == 0                        //settings correct
                && messageTime >= 0                          //after message start time
                && messageTime < message.AudioClip.length;   //before message end

            //stringBuilder.AppendLine($"Message with clip {message.AudioClip.name} is close enough to play: {closeEnoughToPlay} with freqDist {freqDistance}, antDist {antennaDistance}, settings {Convert.ToString(settingsMatch, 2)}, time {messageTime}");

            if (willPlay)
            {
                if (messageFound)
                {
                    Debug.LogError("Found two message that overlap! Remove one of them");
                    continue;
                }

                messageFound = true;
                //m_messagePlayer.volume = 
                SetCurrentMessage(message);
                SetTime(messageTime);
            }
        }

        if(messageFound == false)
        {
            SetCurrentMessage(null);
        }

        //Debug.Log(stringBuilder.ToString());
    }

    private void SetCurrentMessage(Message message)
    {
        if (m_currentMessage == message)
        {
            return;
        }

        m_currentMessage = message;
        m_source.clip = message?.AudioClip;
        m_source.Play();
    }

    private void SetTime(float time)
    {
        if(Mathf.Abs(time - m_source.time) > m_timeBuffer)
        {
            m_source.time = time;
        }
    }
}
