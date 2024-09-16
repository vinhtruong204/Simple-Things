using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombPool : ObjectPooling
{
    // Start is called before the first frame update
    private void Start()
    {
        objectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bomb.prefab");
        transformParent = transform; // Set location to instantiate bomb object
        InitialPool(10); // Start instantiate object with start size of pool is 10
    }

}
