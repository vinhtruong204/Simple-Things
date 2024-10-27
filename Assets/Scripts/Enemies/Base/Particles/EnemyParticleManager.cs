using System;
using UnityEngine;

public class EnemyParticleManager : MonoBehaviour
{
    private Animator animator;
    private EnemyDetectPlayer enemyDetectPlayer;
    private bool isChasing;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyDetectPlayer = transform.parent.GetComponentInChildren<EnemyDetectPlayer>();
    }

    private void Update()
    {
        PlayMoveParticle();
    }

    private void PlayMoveParticle()
    {
        if (enemyDetectPlayer.PlayerDetected && !isChasing)
        {
            animator.SetTrigger(EnemyString.EnemyParticleTrigger.BEGIN_CHASE);
            isChasing = true;
        }

        if (!enemyDetectPlayer.PlayerDetected && isChasing)
        {
            animator.SetTrigger(EnemyString.EnemyParticleTrigger.END_CHASE);
            isChasing = false;
        }
    }
}
