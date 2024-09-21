using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberDamageSender : DamageSender
{
    private CucumberController cucumberController;

    private void Start()
    {
        cucumberController = transform.parent.GetComponent<CucumberController>();
        InitialAmountDamage();
    }

    protected override void InitialAmountDamage()
    {
        amount = cucumberController.CucumberSO.amountDamage;
    }
}
