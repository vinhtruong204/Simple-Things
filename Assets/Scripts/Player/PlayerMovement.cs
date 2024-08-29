using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move left or right
    private readonly float playerSpeed = 5.0f;
    public Rigidbody2D PlayerRb2D { get; private set; }

    // User input
    public float HorizontalInput { get; private set; }

    // Player jump
    private float jumpPower = 7.5f;

    // Check collide with ground
    public bool IsGrounded { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        PlayerRb2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetUserInput();
    }

    private void GetUserInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
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
        if (HorizontalInput == 0.0f)
        {
            PlayerRb2D.velocity = new Vector2(0.0f, PlayerRb2D.velocity.y); // Reset velocity
            return;
        }

        PlayerRb2D.velocity = new Vector2(HorizontalInput * playerSpeed, PlayerRb2D.velocity.y);
    }

    private void Jump()
    {
        IsGrounded = false;
        PlayerRb2D.velocity = new Vector2(PlayerRb2D.velocity.x, jumpPower);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        IsGrounded = true;
    }
}
