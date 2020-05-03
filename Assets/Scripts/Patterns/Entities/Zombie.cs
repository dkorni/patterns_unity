using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.EventHandlers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Zombie : MonoBehaviour, ICharacter
    {
        public GameObject GameObject { get; set; }
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        public ICharacter Enemy { get; set; }

        public void Walk()
        {
            Animator.SetBool("Walking", true);
            StartCoroutine(Walking());
        }

        IEnumerator Walking()
        {
            while (true)
            {
                var target = Enemy.GameObject.transform.position;
                Agent.SetDestination(target);
                yield return null;
            }
          
        }
    }
}