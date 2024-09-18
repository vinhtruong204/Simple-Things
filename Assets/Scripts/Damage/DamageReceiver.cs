using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    public bool IsDead { get; protected set; }

    // Player is being hit
    public bool IsBeingHit { get; protected set; }

    public void Add(int amount)
    {
        if (IsDead) return;

        currentHP += amount;

        if (currentHP >= maxHP)
            currentHP = maxHP;
    }

    public void Deduct(int amount)
    {
        if (IsDead || IsBeingHit) return;

        currentHP -= amount;
        IsBeingHit = true;

        if (currentHP <= 0)
        {
            currentHP = 0;
            IsDead = true;
            DeadHandle();
            return;
        }

        HitHandle();
    }

    protected abstract void HitHandle();

    protected abstract void DeadHandle();
}
