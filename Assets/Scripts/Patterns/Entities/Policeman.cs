using Assets.Scripts.EventHandlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Policeman : MonoBehaviour, ICharacter
    {
        public GameObject GameObject { get; set; }
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        private SortedList<float, Transform> _enemies = new SortedList<float, Transform>();

        public void Walk()
        {
            // idle state
           if(_enemies.Count == 0)
               Idle();
        }

        public void AddEnemy(GameObject enemy)
        {
            _enemies.Add(Vector3.Distance(transform.position, gameObject.transform.position), enemy.transform);
        }

        private void Idle()
        {
            var target = new Vector3(transform.position.x + Random.Range(-4, 4f), transform.position.y,
                transform.position.z + Random.Range(-4f, 4f));
            Agent.SetDestination(target);
            Animator.SetBool("Walking", true);
            var distanceHandler = new DistanceEventHandler(transform, target);
            distanceHandler.Event.AddListener(() =>
            {
                Animator.SetBool("Walking", false);
                Debug.Log("I am hear...");
                Walk();
            });
            EventSystem.Instance.RegisterLoop(distanceHandler);
        }
    }
}