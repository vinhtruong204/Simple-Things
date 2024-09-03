using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed = 5.0f;
    private Rigidbody2D enemyRb;

    // Prevent player change direction twice and get stuck in the wall
    private bool isChangingDirection = false;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
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


        // Flip enemy horizontal
        Flip();
    }


    private void Flip()
    {
        // Get parent game object scale
        Vector3 scale = transform.parent.localScale;

        // Flip horizontal
        scale.x *= -1.0f;

        // Set new parent game object scale
        transform.parent.localScale = scale;
    }
}
