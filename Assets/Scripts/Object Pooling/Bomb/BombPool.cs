using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombPool : ObjectPooling
{
    private readonly int amountInitial = 10;
    
    // Start is called before the first frame update
    private void Start()
    {
        objectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(BombString.BOMB_PREFABS_PATH);
        transformParent = transform; // Set location to instantiate bomb object
        InitialPool(amountInitial); // Start instantiate object with start size of pool is 10
    }

}
