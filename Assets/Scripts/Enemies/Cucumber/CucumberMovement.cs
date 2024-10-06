using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private CucumberAnimation cucumberAnimation;

    private float enemySpeed = 1.5f;

    // Prevent player change direction twice and get stuck in the wall
    protected bool isChangingDirection = false;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
        cucumberAnimation = transform.parent.GetComponentInChildren<CucumberAnimation>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ResetBoolChangingDirection();

        // Move enemy horizontal
        UpdateVelocity();
    }

    private void ResetBoolChangingDirection()
    {
        isChangingDirection = false;
    }

    private void UpdateVelocity()
    {
        Vector2 velocity = enemyRb.velocity;

        // Change move direction depend on enemy's direction
        velocity.x = IsFacingRight() ? enemySpeed : -enemySpeed;

        // Set new velocity
        enemyRb.velocity = velocity;
    }

    private bool IsFacingRight()
    {
        return transform.parent.localScale.x > 0.0f;
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
