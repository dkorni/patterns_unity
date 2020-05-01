using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory : MonoBehaviour
{
    protected abstract ICharacter CreateCharacter();

    public void SpawnCharacter(Vector3 point)
    {
        var character = CreateCharacter();
        character.Walk();
    }
}
