using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ICharacter
{
    NavMeshAgent Agent { get; set; }

    void Walk();
}
