using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberDamageReceiver : DamageReceiver
{
    [SerializeField] private CharacterSO cucumberSO;

    private CucumberAnimation cucumberAnimation;
    private void Start()
    {
        cucumberSO = Resources.Load<CharacterSO>("Enemy/Cucumber");
        cucumberAnimation = transform.parent.GetComponentInChildren<CucumberAnimation>();
        maxHP = cucumberSO.maxHP;
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
