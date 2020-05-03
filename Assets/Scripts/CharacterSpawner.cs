using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.Events;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField]
    private CharacterFactory _characterFactory;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();   
    }

    private void Spawn()
    {
        var character = _characterFactory.SpawnCharacter(transform.position);
    }
}
