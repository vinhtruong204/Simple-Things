using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] private CharacterSO playerSO;

    private void Start()
    {
        playerSO = Resources.Load<CharacterSO>("Player");
        maxHP = playerSO.maxHP;
        currentHP = maxHP;
    }

    private void Update()
    {
        if (isDead) DeadHandle();
    }

    protected override void DeadHandle()
    {

    }
}
