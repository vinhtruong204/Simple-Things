using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeReceiver : MonoBehaviour
{
    private int currentHp;
    private readonly int maxHp;
    private bool isDead;

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
        if (currentHp <= 0) currentHp = 0;
        if (CheckDeaded()) isDead = true;
    }

    private bool CheckDeaded()
    {
        return currentHp <= 0;
    }
}
