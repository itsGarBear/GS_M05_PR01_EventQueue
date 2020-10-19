using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private bool m_IsQuitting;

    public Text text;
    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Launch", Launch);
        }
    }
    void Launch()
    {
        text.text = "Received a launch event : rocket launching!";
    }
}
