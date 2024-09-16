using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Animation control
    private Animator animator;

    // Relate direction and type of animation
    private PlayerMovement playerMovement;
    private Vector3 scale;

    // Get rigidbody 2d
    private Rigidbody2D playerRb2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = transform.parent.GetComponentInChildren<PlayerMovement>();
        playerRb2D = GetComponentInParent<Rigidbody2D>();
        scale = transform.parent.localScale;
    }

    private void Update()
    {
        ChangeDirection();

        SetAnimationType();
    }

    private void ChangeDirection()
    {
        // Player current direction is left and user want to move right
        if (playerMovement.HorizontalInput > 0.0f && scale.x < 0.0f)
        {
            // Flip to the right 
            scale.x *= -1;
        }

        // Player current direction is right and user want to move left
        else if (playerMovement.HorizontalInput < 0.0f && scale.x > 0.0f)
        {
            // Flip to the left
            scale.x *= -1;
        }

        // Change parent scale 
        transform.parent.localScale = scale;
    }

    private void SetAnimationType()
    {
        animator.SetBool("IsJumping", !playerMovement.IsGrounded);
        animator.SetFloat("MoveX", Mathf.Abs(playerRb2D.velocity.x));
        animator.SetFloat("MoveY", playerRb2D.velocity.y);
    }
}
