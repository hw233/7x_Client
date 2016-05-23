﻿using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour
{
    public delegate void eventHandler(GameObject tempObject);

    public delegate void Vector2Handler(GameObject go, Vector2 delta);

    public event eventHandler m_click_handler;

    public event Vector2Handler m_drag_handler;

    public bool IsMultiClickCheck = true;
    public float MultiClickDuration = 0.2f;
    private float lastClickTime;

    void OnClick()
    {
        if (IsMultiClickCheck)
        {
            if (Time.realtimeSinceStartup - lastClickTime < MultiClickDuration)
            {
                return;
            }

            lastClickTime = Time.realtimeSinceStartup;
        }

        if (m_click_handler != null)
        {
            m_click_handler(this.gameObject);
        }
    }

    void OnDrag(Vector2 delta)
    {
        if (m_drag_handler != null)
        {
            m_drag_handler(this.gameObject, delta);
        }
    }
}
