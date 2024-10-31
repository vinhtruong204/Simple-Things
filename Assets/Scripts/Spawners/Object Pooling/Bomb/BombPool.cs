using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class BombPool : ObjectPooling
{
    private readonly int amountInitial = 5;

    // Start is called before the first frame update
    private void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(BombString.BOMB_PREFABS_PATH)
        .Completed += Load_Completed;
    }

    private void Load_Completed(AsyncOperationHandle<GameObject> operationHandle)
    {
        if (operationHandle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Some assets could not loaded");
            return;
        }

        objectPrefab = operationHandle.Result;

        transformParent = transform; // Set location to instantiate bomb object
        InitialPool(amountInitial); // Start instantiate object with start size of pool is 10
    }
}
