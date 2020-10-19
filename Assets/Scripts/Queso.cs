using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Queso : MonoBehaviour
{
    private bool m_IsQuitting;

    public Text text;
    void OnEnable()
    {
        EventBus.StartListening("Queso", Quesod);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Queso", Quesod);
        }
    }
    void Quesod()
    {
        text.text = "Received a queso event : preparing chips and queso!";
    }
}
