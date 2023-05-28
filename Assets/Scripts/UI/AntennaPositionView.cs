using UnityEngine;

public class AntennaPositionView : MonoBehaviour
{
    [SerializeField]
    private AntennaPosition m_antennaPosition;
    [SerializeField]
    private Transform m_DisplayObject;
    [SerializeField]
    private Vector2 m_minPosition;
    [SerializeField]
    private Vector2 m_maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_antennaPosition.XPosition.Subscribe(SetUIPosition);
        m_antennaPosition.YPosition.Subscribe(SetUIPosition);
    }

    private void SetUIPosition()
    {

        float xPos = Mathf.Lerp(m_minPosition.x, m_maxPosition.x, m_antennaPosition.XPosition.Scaled);
        float yPos = Mathf.Lerp(m_minPosition.y, m_maxPosition.y, m_antennaPosition.YPosition.Scaled);

        //Debug.Log($"Moving antenna position UI: {m_antennaPosition.XPosition.Scaled} {m_antennaPosition.YPosition.Scaled} {xPos} {yPos}");

        m_DisplayObject.localPosition = new Vector3(xPos, yPos, m_DisplayObject.localPosition.z);
    }
}
