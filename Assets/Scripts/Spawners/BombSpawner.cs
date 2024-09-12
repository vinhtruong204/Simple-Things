using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner
{
    public static BombSpawner Instance { get; private set; }

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

    public override void SpawnObject()
    {
        // Call the bomb pool to spawn object
        BombPool.Instance.GetGameObject().SetActive(true);
    }

    public override void DeSpawnObject(GameObject obj)
    {
        BombPool.Instance.Release(obj);
    }
}

