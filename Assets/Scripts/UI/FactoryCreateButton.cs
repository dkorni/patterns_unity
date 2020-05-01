using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCreateButton : MonoBehaviour
{
    public CharacterFactory CharacterFactory;

    public void Click()
    {
        CharacterFactory.SpawnCharacter(Vector3.zero+new Vector3(0,3,0));
    }
}
