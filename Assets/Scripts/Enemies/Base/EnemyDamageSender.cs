using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = transform.parent.GetComponent<EnemyController>();
        InitialAmountDamage();
    }

    protected override void InitialAmountDamage()
    {
        amount = enemyController.EnemySO.amountDamage;
    }
}
