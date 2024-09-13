using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombPool : ObjectPooling
{
    public static BombPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        objectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bomb.prefab");
        transformParent = transform; // Set location to instantiate bomb object
        InitialPool(10); // Start instantiate object with start size of pool is 10
    }

}
