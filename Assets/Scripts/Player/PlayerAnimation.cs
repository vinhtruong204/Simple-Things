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


    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = PlayerController.Instance.PlayerMovement;
        scale = new Vector3(1.5f, 1.5f, 0); // Default scale
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
        transform.localScale = scale;
    }

    private void SetAnimationType()
    {
        animator.SetBool("IsRunning", playerMovement.IsRunning);
    }
}
