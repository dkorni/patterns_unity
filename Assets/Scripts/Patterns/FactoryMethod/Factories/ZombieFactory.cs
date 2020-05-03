using Assets.Scripts.Patterns.Entities;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFactory : CharacterFactory
{
    protected override ICharacter CreateCharacter()
    {
        var resource = Resources.Load<GameObject>("Characters/Zombie");
        var go = Instantiate(resource);
        var character = go.AddComponent<Zombie>();
        character.Agent = go.GetComponent<NavMeshAgent>();
        character.Animator = go.GetComponent<Animator>();
        character.GameObject = go.gameObject;
        character.Enemy = FindObjectOfType<Policeman>();
       // EventSystem.Instance.SpawnEnemyEvent.AddListener((g) => character.AddEnemy(g));
        return character;
    }
}