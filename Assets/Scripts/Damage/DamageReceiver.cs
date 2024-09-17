using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected bool isDead;

    public void Add(int amount)
    {
        if (isDead) return;

        currentHP += amount;

        if (currentHP >= maxHP)
            currentHP = maxHP;
    }

    public void Deduct(int amount)
    {
        if (isDead) return;

        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            isDead = true;
        }
    }

    protected abstract void DeadHandle();
}
