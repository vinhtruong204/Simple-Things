using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamgeSender : MonoBehaviour
{
    // Amount damge to send
    protected int amount;

    public void SendDamge(Transform obj)
    {
        DamgeReceiver damgeReceiver = obj.GetComponentInChildren<DamgeReceiver>();
        if (damgeReceiver == null) return;

        this.SendDamge(damgeReceiver);
    }

    private void SendDamge(DamgeReceiver damgeReceiver)
    {
        damgeReceiver.Deduct(amount);
    }
}
