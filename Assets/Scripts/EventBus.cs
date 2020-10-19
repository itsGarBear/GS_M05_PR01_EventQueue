using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;

    public int numEventsInQ = 0;
    private float qDelay = 1f;
    private List<string> eventQ;
    bool isQueue = false;

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
        if (Instance.eventQ == null)
        {
            Instance.eventQ = new List<string>();
        }
    }

    public static void AddEventToQ(string eventName)
    {
        Instance.eventQ.Add(eventName);
        Instance.numEventsInQ++;
    }

    public IEnumerator RunEvent()
    {
        yield return new WaitForSeconds(qDelay);
        while(numEventsInQ > 0)
        {
            TriggerEvent(Instance.eventQ[0]);
            Instance.eventQ.RemoveAt(0);
            Instance.numEventsInQ--;
            yield return new WaitForSeconds(qDelay);
        }
        isQueue = false;
    }
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }
    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
    void Update()
    {
        if (isQueue == false && numEventsInQ > 0)
        {
            StartCoroutine("RunEvent");
            isQueue = true;
        }
    }
}
