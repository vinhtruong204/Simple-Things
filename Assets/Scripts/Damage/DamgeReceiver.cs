using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamgeReceiver : MonoBehaviour
{
    [SerializeField] protected int currentHp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected bool isDead;

    public void Add(int amount)
    {
        if (isDead) return;

        currentHp += amount;

        if (currentHp >= maxHp)
            currentHp = maxHp;
    }

    public void Deduct(int amount)
    {
        if (isDead) return;

        currentHp -= amount;

        if (currentHp <= 0)
        {
            currentHp = 0;
            isDead = true;
        }
    }

    protected abstract void DeadHandle();
}
