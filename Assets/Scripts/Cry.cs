using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cry : MonoBehaviour
{
    private bool m_IsQuitting;

    public Text text;
    void OnEnable()
    {
        EventBus.StartListening("Cry", Cried);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Cry", Cried);
        }
    }
    void Cried()
    {
        text.text = "Received a cry event : crying uncontrollably!";
    }
}
