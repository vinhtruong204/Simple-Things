using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBomb : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Throw a bomb from the bomb pool
            BombSpawner.Instance.SpawnObject();
        }
    }
}
