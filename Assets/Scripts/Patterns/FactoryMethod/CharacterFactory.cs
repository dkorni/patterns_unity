using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory : MonoBehaviour
{
    protected abstract ICharacter CreateCharacter(Vector3 point);

    public ICharacter SpawnCharacter(Vector3 point)
    {
        var character = CreateCharacter(point);
        character.Walk();
        return character;
    }
}
