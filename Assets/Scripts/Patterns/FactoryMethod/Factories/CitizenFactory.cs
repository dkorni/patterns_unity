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
        public override ICharacter CreateCharacter()
        {
            var gameObject = Resources.Load<GameObject>("Characters/Citizen");
            var character = gameObject.AddComponent<Citizen>();
            character.Agent = gameObject.GetComponent<NavMeshAgent>();
            character.Animator = gameObject.GetComponent<Animator>();
            return character;
        }
    }
}