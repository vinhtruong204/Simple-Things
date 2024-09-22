using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberAnimation : MonoBehaviour, IDamageAnimation
{
    private bool isAttacking;
    private BoxCollider2D enemyAttackBox;
    private CucumberDamageSender cucumberDamageSender;

    private BoxCollider2D playerBox;
    private GameObject player;

    private Animator animator;

    // Handle hit and dead hit animation
    private CucumberDamageReceiver cucumberDamageReceiver;

    // Reference movement
    private CucumberMovement cucumberMovement;

    // Start is called before the first frame update
    private void Start()
    {
        LoadPlayerComponents();

        LoadAllComponents();
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
        cucumberDamageSender = transform.parent.GetComponentInChildren<CucumberDamageSender>();
        cucumberDamageReceiver = transform.parent.GetComponentInChildren<CucumberDamageReceiver>();
        cucumberMovement = transform.parent.GetComponentInChildren<CucumberMovement>();
    }

    private void Update()
    {
        UpdateCurrentAttackState();
    }

    private void UpdateCurrentAttackState()
    {
        // if enemy is being hit => can't attack
        if (cucumberDamageReceiver.IsBeingHit || cucumberDamageReceiver.IsDead) return;

        animator.SetBool("IsAttacking", isAttacking);
    }

    public void Flip()
    {
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
            cucumberDamageSender.SendDamage(player.transform);
        }

        isAttacking = false;
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name != "Player") return;

        isAttacking = true;

        // Player direction oposite with enemy
        if (other.gameObject.transform.localScale.x * transform.parent.localScale.x > 0.0f)
        {
            Flip();
        }

    }

    public void PlayHitAnimation()
    {
        animator.SetTrigger("IsBeingHit");
    }

    public void HitFinished()
    {
        cucumberDamageReceiver.ResetIsBeingHit();
    }

    public void PlayDeadHitAnimation()
    {
        animator.SetTrigger("DeadHit");
    }

    public void DeadGroundFinished()
    {
        Debug.Log("Enemy deaded");
        Destroy(transform.parent.gameObject);
    }
}
