using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberDamageReceiver : DamageReceiver
{
    [SerializeField] private CharacterSO cucumberSO;
    private void Start()
    {
        cucumberSO = Resources.Load<CharacterSO>("Enemy/Cucumber");
        maxHP = cucumberSO.maxHP;
        currentHP = maxHP;

    }
    protected override void DeadHandle()
    {
        throw new System.NotImplementedException();
    }
}
