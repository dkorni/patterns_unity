using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    [Serializable]
    public class SpawnEvent : UnityEvent<ICharacter> { }
}
