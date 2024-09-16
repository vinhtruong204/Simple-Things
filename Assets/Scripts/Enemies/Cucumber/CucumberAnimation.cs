using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberAnimation : CucumberController
{
    private bool isAttacking;
    private BoxCollider2D enemyAttackBox;
    private BoxCollider2D playerBox;
    public bool AttackSucceed { get; private set; }


    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        LoadAllComponents();
    }

    private void LoadAllComponents()
    {
        animator = GetComponent<Animator>();
        enemyAttackBox = transform.parent.GetChild(2).GetComponent<BoxCollider2D>();
        playerBox = GameObjectManager.Instance.Player.GetComponent<BoxCollider2D>();
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
            AttackSucceed = true;
            // Debug.Log("send damage");
        }

        isAttacking = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            isAttacking = true;
    }
}
