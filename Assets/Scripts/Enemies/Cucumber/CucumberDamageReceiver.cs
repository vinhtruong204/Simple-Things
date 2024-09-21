using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberDamageReceiver : DamageReceiver
{
    private CucumberController cucumberController;

    private CucumberAnimation cucumberAnimation;

    private void Start()
    {
        cucumberController = transform.parent.GetComponent<CucumberController>();
        cucumberAnimation = cucumberController.CucumberAnimation;
        maxHP = cucumberController.CucumberSO.maxHP;
        currentHP = maxHP;
    }

    protected override void HitHandle()
    {
        cucumberAnimation.PlayHitAnimation();
    }

    protected override void DeadHandle()
    {
        cucumberAnimation.PlayDeadHitAnimation();
    }

}
