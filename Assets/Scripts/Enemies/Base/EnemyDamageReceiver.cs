using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyDamageReceiver : DamageReceiver
{
    private EnemyController enemyController;

    private EnemyAnimation enemyAnimation;

    private CharacterMaxHPSO enemyMaxHP;

    private void Start()
    {
        enemyController = transform.parent.GetComponent<EnemyController>();
        enemyAnimation = enemyController.EnemyAnimation;

        LoadScriptableObject();
    }

    private void LoadScriptableObject()
    {
        Addressables.LoadAssetAsync<CharacterMaxHPSO>(transform.parent.name)
        .Completed += (handle) =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("Some enemy scriptable object not loaded!");
                return;
            }

            enemyMaxHP = handle.Result;
            MaxHP = enemyMaxHP.maxHP;
            CurrentHP = MaxHP;
        };
    }

    protected override void HitHandle()
    {
        enemyAnimation.PlayHitAnimation();
    }

    protected override void DeadHandle()
    {
        enemyAnimation.PlayDeadHitAnimation();
    }

}
