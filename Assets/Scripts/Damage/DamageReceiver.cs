using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    public int CurrentHP { get; protected set; }
    public int MaxHP { get; protected set; }
    public bool IsDead { get; protected set; }

    // Player is being hit
    public bool IsBeingHit { get; protected set; }

    public bool Add(int amount)
    {
        if (IsDead) return false;

        CurrentHP += amount;

        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
            return false;
        }
        return true;
    }

    public void Deduct(int amount)
    {
        if (IsDead || IsBeingHit) return;

        CurrentHP -= amount;


        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
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
