using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CucumberMovement : CucumberController
{
    // Start is called before the first frame update
    private void Start()
    {

        enemyRb = GetComponentInParent<Rigidbody2D>();
        cucumberAnimation = transform.parent.GetComponentInChildren<CucumberAnimation>();
    }

    private bool IsFacingRight()
    {
        return transform.parent.localScale.x > Mathf.Epsilon; // 0.0001f
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ResetBoolChangingDirection();

        // Move enemy horizontal
        ChangeMoveDirection();
    }

    private void ResetBoolChangingDirection()
    {
        isChangingDirection = false;
    }

    private void ChangeMoveDirection()
    {
        // Get current rigidbody2d velocity
        Vector2 velocity = enemyRb.velocity;

        // Change move direction depend on enemy's direction
        velocity.x = IsFacingRight() ? enemySpeed : -enemySpeed;

        // Set new velocity
        enemyRb.velocity = velocity;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If enemy is changing direction 
        if (isChangingDirection) return;

        // Prevent this method from being called and change direction on the next call
        isChangingDirection = true;


        // Flip enemy's sprite horizontal
        cucumberAnimation.Flip();
    }

}
