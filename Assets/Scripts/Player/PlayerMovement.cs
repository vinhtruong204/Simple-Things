using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move left or right
    private Rigidbody2D playerRb2D;
    private float playerSpeed = 5.0f;
    public bool IsRunning { get; private set; }

    // User input
    private float horizontalInput;

    // Player jump
    private float jumpPower = 5.0f;


    // Start is called before the first frame update
    private void Start()
    {
        playerRb2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetUserInput();
    }

    private void GetUserInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        ChangeVelocity();

        if (Input.GetButtonDown("Jump"))
            Jump();
    }
    private void ChangeVelocity()
    {
        // If player not running
        if (horizontalInput == 0.0f)
        {
            IsRunning = false;
            playerRb2D.velocity = new Vector2(0.0f, playerRb2D.velocity.y); // Reset velocity
            return;
        }

        IsRunning = true;
        playerRb2D.velocity = new Vector2(horizontalInput * playerSpeed, playerRb2D.velocity.y);
    }

    private void Jump()
    {
        playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, jumpPower);
    }
}
