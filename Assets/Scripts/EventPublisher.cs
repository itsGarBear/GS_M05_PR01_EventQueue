using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
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
    }
}
