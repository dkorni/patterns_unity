using System.Collections.Generic;
using Assets.Scripts.EventHandlers;
using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

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
                _instance.SpawnEnemyEvent = new SpawnEvent();
            }

            return _instance;
        }
    }

    public SpawnEvent SpawnEnemyEvent { get; set; }

    public void RegisterLoop(IHandler handler)
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
