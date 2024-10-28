using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerDamageReceiver : DamageReceiver
{
    private CharacterMaxHPSO playerMaxHPSO;
    private PlayerAnimation playerAnimation;

    private void Start()
    {
        LoadScriptableObject();

        playerAnimation = transform.parent.GetComponentInChildren<PlayerAnimation>();
    }

    private void LoadScriptableObject()
    {
        Addressables.LoadAssetAsync<CharacterMaxHPSO>(ScriptableObjectString.PlayerSOPath.MAXHP_PATH)
        .Completed += (handle) =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("Player max hp scriptable object couldn't loaded!");
                return;
            }

            playerMaxHPSO = handle.Result;
            MaxHP = playerMaxHPSO.maxHP;
            CurrentHP = MaxHP;
        };
    }

    protected override void HitHandle()
    {
        playerAnimation.PlayHitAnimation();
    }

    protected override void DeadHandle()
    {
        playerAnimation.PlayDeadHitAnimation();
    }
}
