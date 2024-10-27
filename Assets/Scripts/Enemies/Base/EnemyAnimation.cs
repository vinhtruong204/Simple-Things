using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour, IDamageAnimation, IAddAnimationEvent
{
    private bool isAttacking;
    private BoxCollider2D enemyAttackBox;
    private EnemyDamageSender enemyDamageSender;

    private BoxCollider2D playerBox;
    private GameObject player;

    private Animator animator;

    // Handle hit and dead hit animation
    private EnemyDamageReceiver enemyDamageReceiver;

    // Reference movement
    private EnemyMovement enemyMovement;

    // Detect player depend on distance and angle
    private EnemyDetectPlayer enemyDetectPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        LoadPlayerComponents();

        LoadAllComponents();

        AddAnimationEvent();
    }

    public void AddAnimationEvent()
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            AnimationEvent aniEvent = new()
            {
                time = clip.length
            };

            switch (clip.name)
            {
                case "Hit":
                    aniEvent.functionName = nameof(HitFinished);
                    break;
                case "Attack":
                    aniEvent.functionName = nameof(AttackFinished);
                    break;
                case "Dead Ground":
                    aniEvent.functionName = nameof(DeadGroundFinished);
                    break;
                default:
                    continue;
            }

            clip.AddEvent(aniEvent);
        }

    }

    private void LoadPlayerComponents()
    {
        player = GameObjectManager.Instance.Player;
        playerBox = player.GetComponent<BoxCollider2D>();
    }

    private void LoadAllComponents()
    {
        animator = GetComponent<Animator>();
        enemyAttackBox = transform.parent.GetComponent<BoxCollider2D>();
        enemyDamageSender = transform.parent.GetComponentInChildren<EnemyDamageSender>();
        enemyDamageReceiver = transform.parent.GetComponentInChildren<EnemyDamageReceiver>();
        enemyMovement = transform.parent.GetComponentInChildren<EnemyMovement>();
        enemyDetectPlayer = transform.parent.GetComponentInChildren<EnemyDetectPlayer>();
    }

    private void Update()
    {
        UpdateCurrentAttackState();

        UpdateEnemyDirection();
    }

    private void UpdateEnemyDirection()
    {
        if (!enemyDetectPlayer.PlayerDetected) return;

        if (IsFacingRight() && player.transform.position.x < transform.position.x)
        {
            Flip();
        }
        else if (!IsFacingRight() && player.transform.position.x > transform.position.x)
        {
            Flip();
        }
    }

    private bool IsFacingRight()
    {
        return transform.parent.localScale.x > 0.0f;
    }

    private void UpdateCurrentAttackState()
    {
        // if enemy is being hit => can't attack
        if (enemyDamageReceiver.IsBeingHit || enemyDamageReceiver.IsDead) return;

        animator.SetBool(EnemyString.EnemyAnimationParameters.IS_ATTACKING, isAttacking);
    }

    public void Flip()
    {
        if (isAttacking) return;

        // Get parent game object scale
        Vector3 scale = transform.parent.localScale;

        // Flip horizontal
        scale.x *= -1.0f;

        // Set new parent game object scale
        transform.parent.localScale = scale;
    }

    public void AttackFinished()
    {
        // Send damage when finished attack animation
        if (enemyAttackBox.IsTouching(playerBox))
        {
            // Attack succeed
            enemyDamageSender.SendDamage(player.transform);
        }

        isAttacking = false;
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name != GameObjectString.GameObjectName.PLAYER_NAME) return;

        isAttacking = true;

        // Play attack sound
        SoundFXManager.Instance.PlaySound(AudioString.SoundString.ENEMY_ATTACK);

        // Player direction oposite with enemy
        if (other.gameObject.transform.localScale.x * transform.parent.localScale.x > 0.0f)
        {
            Flip();
        }

    }

    public void PlayHitAnimation()
    {
        animator.SetTrigger(EnemyString.EnemyAnimationParameters.IS_BEING_HIT);
    }

    public void HitFinished()
    {
        enemyDamageReceiver.ResetIsBeingHit();
    }

    public void PlayDeadHitAnimation()
    {
        animator.SetTrigger(EnemyString.EnemyAnimationParameters.DEAD_HIT);
    }

    public void DeadGroundFinished()
    {
        Debug.Log("Enemy deaded");
        Destroy(transform.parent.gameObject);
    }
}
