using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerController : NetworkBehaviour
{
    public static event Action<GameObject> OnPlayerSpawned;
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }

    private readonly List<Vector3> levelSpawnPosition = new();

    private void Awake()
    {
        PlayerMovement = GetComponentInChildren<PlayerMovement>();
        PlayerAnimation = GetComponentInChildren<PlayerAnimation>();

        levelSpawnPosition.Add(new Vector3(-10f, 0f));
        levelSpawnPosition.Add(new Vector3(20.5f, -7f));
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            OnPlayerSpawned?.Invoke(gameObject);
        }

        transform.position = levelSpawnPosition[SceneManager.GetActiveScene().buildIndex - 1];
    }
}
