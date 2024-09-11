using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour, ISpawner
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

    public void SpawnObject()
    {
        // Call the bomb pool to spawn object
        BombPool.Instance.BombPooling.GetGameObject().SetActive(true);
    }

    public void DeSpawnObject(GameObject obj)
    {
        BombPool.Instance.BombPooling.Release(obj);
    }
}

