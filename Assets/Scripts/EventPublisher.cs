using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPublisher : MonoBehaviour
{
    public Text text;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventBus.TriggerEvent("Cry");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            EventBus.AddEventToQ("Launch");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventBus.TriggerEvent("Pineapple");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventBus.TriggerEvent("Queso");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.TriggerEvent("Shoot");
        }
        text.text = "Events in Queue: " + EventBus.Instance.numEventsInQ;
    }
}
