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
        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public GameObject GameObject { get; set; }
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        [SerializeField]
        private float health = 100;

        private Coroutine _walkCoroutine;

        public ICharacter Enemy { get; set; }

        public void Walk()
        {
            Animator.SetBool("Walking", true);
            _walkCoroutine = StartCoroutine(Walking());
        }

        public void SetDamage(float damage)
        {
            health -= damage;

            if (health == 0 || health < 0)
            {
                Animator.SetTrigger("Die");
                Agent.isStopped = true;
                StopCoroutine(_walkCoroutine);
            }
            else
                Animator.Play("Hit");
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