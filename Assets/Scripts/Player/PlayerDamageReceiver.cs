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
        playerSO = Resources.Load<CharacterSO>("Player");
        maxHP = playerSO.maxHP;
        currentHP = maxHP;
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
