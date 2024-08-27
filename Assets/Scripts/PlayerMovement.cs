using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move left or right
    private Rigidbody2D playerRb2D;
    private float playerSpeed = 5.0f;

    // User input
    private float horizontalInput;

    // Player jump
    private float jumpPower = 5.0f;
    private bool isRunning;

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
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
            ChangeVelocity();

        if (Input.GetButtonDown("Jump"))
            Jump();
    }
    private void ChangeVelocity()
    {
        playerRb2D.velocity = new Vector2(horizontalInput * playerSpeed, playerRb2D.velocity.y);
    }

    private void Jump()
    {
        playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, jumpPower);
    }
}
