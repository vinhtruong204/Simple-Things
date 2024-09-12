using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeSender : MonoBehaviour
{
    private readonly int amount = 1;

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
