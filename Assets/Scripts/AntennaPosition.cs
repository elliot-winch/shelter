using UnityEngine;


public class AntennaPosition : MonoBehaviour
{
    [SerializeField]
    private float m_yMax;
    [SerializeField]
    private float m_yMin;
    [SerializeField]
    private float m_xMax;
    [SerializeField]
    private float m_xMin;
    [SerializeField]
    private Vector2 m_startingPosition;

    public BoundedValueTopic XPosition { get; } = new BoundedValueTopic();
    public BoundedValueTopic YPosition { get; } = new BoundedValueTopic();

    public Vector2 Position => new Vector2 (XPosition.Value, YPosition.Value);

    private void Awake()
    {
        YPosition.Max = m_yMax;
        YPosition.Min = m_yMin;
        XPosition.Max = m_xMax;
        XPosition.Min = m_xMin;

        XPosition.Value = m_startingPosition.x;
        YPosition.Value = m_startingPosition.y; 
    }

    //For use in the inspector
    public void MoveYPositionBy(float amount)
    {
        YPosition.Value += amount;
    }

    //For use in the inspector
    public void MoveXPositionBy(float amount)
    {
        XPosition.Value += amount;
    }
}
