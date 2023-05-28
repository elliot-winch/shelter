using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Button : MonoBehaviour
{
    [SerializeField]
    private bool m_onMouseDown;
    [SerializeField]
    private bool m_onMouse;

    [Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent OnClicked;

    private void OnMouseOver()
    {
        if (m_onMouseDown && Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }

        if (m_onMouse && Input.GetMouseButton(0))
        {
            OnClicked?.Invoke();
        }
    }
}
