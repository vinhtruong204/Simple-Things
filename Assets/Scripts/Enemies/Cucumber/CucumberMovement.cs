using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberMovement : MonoBehaviour
{
    [Header("Enemy speed")]
    private const float SPEED_NORMAL = 1.5f;
    private const float SPEED_ACCELERATE = SPEED_NORMAL * 2.5f;
    private float enemySpeed = SPEED_NORMAL;

    // Set the enemy speed depends on the current state
    private EnemyDetectPlayer enemyDetectPlayer;


    private Rigidbody2D enemyRb;
    private CucumberAnimation cucumberAnimation;


    // Prevent player change direction twice and get stuck in the wall
    protected bool isChangingDirection = false;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
        cucumberAnimation = transform.parent.GetComponentInChildren<CucumberAnimation>();
        enemyDetectPlayer = transform.parent.GetComponentInChildren<EnemyDetectPlayer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ResetBoolChangingDirection();

        SetEnemySpeed();

        // Move enemy horizontal
        UpdateVelocity();
    }

    private void SetEnemySpeed()
    {
        enemySpeed = enemyDetectPlayer.PlayerDetected ? SPEED_ACCELERATE : SPEED_NORMAL;
    }

    private void ResetBoolChangingDirection()
    {
        isChangingDirection = false;
    }

    private void UpdateVelocity()
    {
        Vector2 velocity = enemyRb.linearVelocity;

        // Change move direction depend on enemy's direction
        velocity.x = IsFacingRight() ? enemySpeed : -enemySpeed;

        // Set new velocity
        enemyRb.linearVelocity = velocity;
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
