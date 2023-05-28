using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private Transform m_transform;
    [SerializeField]
    private Vector2 m_Sensitivity;
    [SerializeField]
    private Vector2 m_xRotationBounds;
    [SerializeField]
    private Vector2 m_yRotationBounds;

    private float yRotation;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * m_Sensitivity.x;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * m_Sensitivity.y;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, m_xRotationBounds.x, m_xRotationBounds.y);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, m_yRotationBounds.x, m_yRotationBounds.y);

        m_transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
