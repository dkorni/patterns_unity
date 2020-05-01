using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.EventHandlers
{
    public class DistanceEventHandler : EventHandlerBase
    {
        private Transform _target;
        private Vector3 _location;
        private bool _isСlose;

        public DistanceEventHandler(Transform target, Vector3 location) : base()
        {
            _target = target;
            _location = location;
        }

        public override IEnumerator HandleCoroutine()
        {
            while (!_isСlose)
            {
                if (Vector3.Distance(_target.position, _location) < 0.1f)
                {
                    _isСlose = true;
                    Event.Invoke();
                }

                yield return null;
            }
        }
    }
}
