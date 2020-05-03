using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ICharacter
{
    GameObject GameObject { get; set; }

    NavMeshAgent Agent { get; set; }

    void Walk();
}
