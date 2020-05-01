using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    // store handlers in memory
    private readonly List<IHandler> _handlers = new List<IHandler>();

    private static EventSystem _instance;

    public static EventSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                var eventSystem = Resources.Load<GameObject>("EventSystem");
                var go = Instantiate(eventSystem);
                _instance = go.GetComponent<EventSystem>();
            }

            return _instance;
        }
    }

    public void Register(IHandler handler)
    {
        _handlers.Add(handler);
        var coroutine = StartCoroutine(handler.HandleCoroutine());
        handler.Event.AddListener(()=>Deregister(handler, coroutine));
    }

    public void Deregister(IHandler handler, Coroutine coroutine)
    {
        StopCoroutine(coroutine);
        _handlers.Remove(handler);
    }
}
