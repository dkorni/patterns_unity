using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCharacterCreator : MonoBehaviour
{
    public CharacterFactory Factory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 1000))
            {
                if (hitInfo.transform.name == "Plane")
                {
                    Factory.SpawnCharacter(hitInfo.point);
                    Debug.Log(hitInfo.point);
                }
            }
        }
    }
}
