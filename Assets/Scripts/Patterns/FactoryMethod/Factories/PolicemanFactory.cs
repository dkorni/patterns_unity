using Assets.Scripts.Patterns.Entities;
using UnityEngine;
using UnityEngine.AI;

public class PolicemanFactory : CharacterFactory
{
    protected override ICharacter CreateCharacter(Vector3 point)
    {
        var resource = Resources.Load<GameObject>("Characters/Policeman");
        var go = Instantiate(resource);
        var character = go.AddComponent<Policeman>();
        character.Agent = go.GetComponent<NavMeshAgent>();
        character.Animator = go.GetComponent<Animator>();
        character.GameObject = go.gameObject;
        EventSystem.Instance.SpawnEnemyEvent.AddListener((g)=>character.AddEnemy(g));
        return character;
    }
}
