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

    public bool Add(int amount)
    {
        if (IsDead) return false;

        currentHP += amount;

        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
            return false;
        }

        return true;
    }

    public void Deduct(int amount)
    {
        if (IsDead || IsBeingHit) return;

        currentHP -= amount;


        if (currentHP <= 0)
        {
            currentHP = 0;
            IsDead = true;
            DeadHandle();
            return;
        }

        IsBeingHit = true;
        HitHandle();
    }

    public void ResetIsBeingHit()
    {
        IsBeingHit = false;
    }

    protected abstract void HitHandle();

    protected abstract void DeadHandle();
}
