using System;
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
        // User request throw a bomb
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Throw a bomb from the bomb pool
            ThrowBomb();
        }
    }

    public void ThrowBomb()
    {
        if (playerDamageReceiver.IsDead) return;

        BombSpawner.Instance.SpawnObject();
    }
}
