using Assets.Scripts.EventHandlers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Citizen : MonoBehaviour, ICharacter
    {
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        public void Walk()
        {
            var target = new Vector3(transform.position.x + Random.Range(-4, 4f), transform.position.y,
                transform.position.z + Random.Range(-4f, 4f));
            Agent.SetDestination(target);
            var distanceHandler = new DistanceEventHandler(transform, target);
            distanceHandler.Event.AddListener(()=>
            {
                Debug.Log("I am hear...");
                Walk();
            });
            EventSystem.Instance.Register(distanceHandler);
        }
    }
}
