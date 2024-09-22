using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBomb : MonoBehaviour
{
    private PlayerDamageReceiver playerDamageReceiver;

    private void Start()
    {
        playerDamageReceiver = transform.parent.GetComponentInChildren<PlayerDamageReceiver>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !playerDamageReceiver.IsDead)
        {
            // Throw a bomb from the bomb pool
            BombSpawner.Instance.SpawnObject();
        }
    }
}
