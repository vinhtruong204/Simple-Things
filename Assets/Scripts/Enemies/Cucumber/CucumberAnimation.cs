using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberAnimation : CucumberController
{
    private bool isAttacking;
    private BoxCollider2D enemyBox;
    private BoxCollider2D playerBox;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        cucumberMovement = transform.parent.GetComponentInChildren<CucumberMovement>();
        enemyBox = transform.parent.GetComponent<BoxCollider2D>();
        // playerBox = GameObjectManager.Instance.Player.GetComponent<BoxCollider2D>();
        playerBox = PlayerController.Instance.GetComponent<BoxCollider2D>();
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
        if (enemyBox.IsTouching(playerBox))
        {
            Debug.Log("send damage");
        }

        isAttacking = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            isAttacking = true;
    }
}
