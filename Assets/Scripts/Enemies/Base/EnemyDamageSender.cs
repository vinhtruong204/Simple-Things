using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyDamageSender : DamageSender
{
    private EnemyController enemyController;

    public EnemyDamageSenderSO enemyDamageSender;

    private void Start()
    {
        LoadScriptableObject();

        enemyController = transform.parent.GetComponent<EnemyController>();
    }

    private void LoadScriptableObject()
    {
        Addressables.LoadAssetAsync<EnemyDamageSenderSO>(transform.parent.name)
        .Completed += (handle) =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("Enemy damge scriptable object could not loaded!");
                return;
            }

            enemyDamageSender = handle.Result;
            InitialAmountDamage();
        };
    }

    protected override void InitialAmountDamage()
    {
        amount = enemyDamageSender.amountDamage;
    }
}
