using Assets.Scripts.Patterns.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Patterns.FactoryMethod.Factories
{
    public class CitizenFactory : CharacterFactory
    {
        /// <summary>
        /// Fabric method. Creates the citizen character amd setup it.
        /// </summary>
        /// <returns></returns>
        protected override ICharacter CreateCharacter(Vector3 point)
        {
            var resource = Resources.Load<GameObject>("Characters/Citizen");
            var go = Instantiate(resource);
            var character = go.AddComponent<Citizen>();
            character.Agent = go.GetComponent<NavMeshAgent>();
            character.Animator = go.GetComponent<Animator>();
            character.GameObject = go.gameObject;
            return character;
        }
    }
}