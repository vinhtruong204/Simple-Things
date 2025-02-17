using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerThrowBomb : NetworkBehaviour
{
    // Check player deaded
    private PlayerDamageReceiver playerDamageReceiver;

    // Handle active game object bombBar
    private BombBarAnimation bombBarAnimation;

    private void Start()
    {
        playerDamageReceiver = transform.parent.GetComponentInChildren<PlayerDamageReceiver>();
        bombBarAnimation = transform.parent.GetComponentInChildren<BombBarAnimation>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsOwner) return;
        // User request throw a bomb
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Throw a bomb from the bomb pool
            ThrowBomb();
        }
    }

    public void ThrowBomb()
    {
        // If the player is dead or has not completed the bomb charging animation
        if (playerDamageReceiver.IsDead || !bombBarAnimation.CanThrowBomb) return;

        bombBarAnimation.gameObject.SetActive(true);
        BombSpawner.Instance.SpawnObject();
    }
}
