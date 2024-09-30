using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] private CharacterSO playerSO;
    private PlayerAnimation playerAnimation;

    private void Start()
    {
        playerSO = Resources.Load<CharacterSO>(ScriptableObjectString.PlayerSOPath.PATH);
        MaxHP = playerSO.maxHP;
        CurrentHP = MaxHP;
        playerAnimation = transform.parent.GetComponentInChildren<PlayerAnimation>();
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
