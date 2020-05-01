using System.Collections;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.EventHandlers
{
    public abstract class EventHandlerBase : IHandler
    {
        public EventHandlerBase()
        {
            Event = new UnityEvent();
        }

        public UnityEvent Event { get; }

        public abstract IEnumerator HandleCoroutine();
    }
}
