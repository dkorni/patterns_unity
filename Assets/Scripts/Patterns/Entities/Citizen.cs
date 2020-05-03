using Assets.Scripts.EventHandlers;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Citizen : MonoBehaviour, ICharacter
    {
        public float Health { get; set; }
        public GameObject GameObject { get; set; }
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        public void Walk()
        {
            var target = new Vector3(transform.position.x + Random.Range(-4, 4f), transform.position.y,
                transform.position.z + Random.Range(-4f, 4f));
            Agent.SetDestination(target);
            Animator.SetBool("Walking", true);
            var distanceHandler = new DistanceEventHandler(transform, target);
            distanceHandler.Event.AddListener(()=>
            {
                Animator.SetBool("Walking", false);
                Debug.Log("I am hear...");
                Walk();
            });
            EventSystem.Instance.RegisterLoop(distanceHandler);
        }

        public void SetDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
