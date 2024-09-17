using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberAnimation : CucumberController
{
    private bool isAttacking;
    private BoxCollider2D enemyAttackBox;
    private CucumberDamageSender cucumberDamageSender;

    private BoxCollider2D playerBox;
    private GameObject player;

    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        LoadAllComponents();
    }

    private void LoadAllComponents()
    {
        animator = GetComponent<Animator>();
        enemyAttackBox = transform.parent.GetComponent<BoxCollider2D>();
        player = GameObjectManager.Instance.Player;
        playerBox = player.GetComponent<BoxCollider2D>();
        cucumberDamageSender = transform.parent.GetComponentInChildren<CucumberDamageSender>();
    }

    private void Update()
    {
        UpdateCurrentState();
    }

    private void UpdateCurrentState()
    {
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
        if (other.gameObject.name == "Player")
        {
            isAttacking = true;
        }
    }
}
