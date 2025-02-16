using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : NetworkBehaviour
{
    public static event Action<GameObject> OnPlayerSpawned;
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }

    private void Start()
    {
        PlayerMovement = GetComponentInChildren<PlayerMovement>();
        PlayerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            OnPlayerSpawned?.Invoke(gameObject);
        }
        
    }
}
