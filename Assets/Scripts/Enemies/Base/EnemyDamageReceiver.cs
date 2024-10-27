using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    private EnemyController enemyController;

    private EnemyAnimation enemyAnimation;

    private void Start()
    {
        enemyController = transform.parent.GetComponent<EnemyController>();
        enemyAnimation = enemyController.EnemyAnimation;
        MaxHP = enemyController.EnemySO.maxHP;
        CurrentHP = MaxHP;
    }

    protected override void HitHandle()
    {
        enemyAnimation.PlayHitAnimation();
    }

    protected override void DeadHandle()
    {
        enemyAnimation.PlayDeadHitAnimation();
    }

}
