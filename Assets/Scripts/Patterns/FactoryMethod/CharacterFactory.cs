using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory
{
    public abstract ICharacter CreateCharacter();

    public void SpawnCharacter(Vector3 point)
    {
        var character = CreateCharacter();
        character.Walk();
    }
}
