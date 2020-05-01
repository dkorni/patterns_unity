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
            var target = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y,
                transform.position.z + Random.Range(-0.5f, 0.5f));
            Agent.SetDestination(target);
        }
    }
}
