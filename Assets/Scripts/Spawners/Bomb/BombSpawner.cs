using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner
{
    public static BombSpawner Instance { get; private set; }

    private BombPool bombPool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    private void Start()
    {
        bombPool = GetComponentInChildren<BombPool>();
    }

    public override void SpawnObject()
    {
        // Call the bomb pool to spawn object
        bombPool.GetGameObject().SetActive(true);
    }

    public override void DeSpawnObject(GameObject obj)
    {
        bombPool.Release(obj);
    }
}

