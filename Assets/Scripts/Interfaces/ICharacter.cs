using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ICharacter
{
    float Health { get; set; }

    GameObject GameObject { get; set; }

    NavMeshAgent Agent { get; set; }

    void Walk();

    void SetDamage(float damage);
}
