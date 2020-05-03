using Assets.Scripts.EventHandlers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.Entities
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Policeman : MonoBehaviour, ICharacter
    {
        public float Health { get; set; }
        public GameObject GameObject { get; set; }
        public NavMeshAgent Agent { get; set; }
        public Animator Animator { get; set; }

        private SortedList<float, ICharacter> _enemies = new SortedList<float, ICharacter>();

        public void Walk()
        {
            Idle();
            StartCoroutine(Walking());
        }

        public void SetDamage(float damage)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator Walking()
        {
            while (true)
            {
                // idle state
                if (_enemies.Count > 0)
                {
                    AttackMode();
                }

                yield return null;
            }
        }

        public void AddEnemy(ICharacter enemy)
        {
            _enemies.Add(Vector3.Distance(transform.position, enemy.GameObject.transform.position), enemy);
        }

        private void Idle()
        {
            if (_enemies.Count == 0)
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
                    Idle();
                });
                EventSystem.Instance.RegisterLoop(distanceHandler);
            }
        }

        private void AttackMode()
        {
            if (Animator.GetBool("Walking"))
            {
                Animator.SetBool("Walking", false);
                Animator.SetBool("Attack", true);
                Agent.isStopped = true;
                StartCoroutine(Attack());
            }

            transform.LookAt(_enemies.FirstOrDefault().Value.GameObject.transform);
        }

        IEnumerator Attack()
        {
            while (true)
            {
                _enemies.FirstOrDefault().Value.SetDamage(50);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}