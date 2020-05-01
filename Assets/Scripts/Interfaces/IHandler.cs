using System.Collections;
using UnityEngine.Events;

namespace Assets.Scripts.Interfaces
{
    public interface IHandler
    {
        UnityEvent Event { get; }

        IEnumerator HandleCoroutine();
    }
}
