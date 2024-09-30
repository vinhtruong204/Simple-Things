using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int MAXIMUM_NUMBER_JUMPS = 2;
    // Move left or right
    private readonly float playerSpeed = 5.0f;
    public Rigidbody2D PlayerRb2D { get; private set; }

    // User input
    public float HorizontalInput { get; private set; }

    // Player jump
    private readonly float jumpPower = 8.0f;
    private int jumpsLeft = MAXIMUM_NUMBER_JUMPS;

    // Check collide with ground
    public bool IsGrounded { get; private set; }

    [SerializeField] private Joystick joystick;

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


        if (HorizontalInput == 0)
            HorizontalInput = joystick.Horizontal;
    }

    private void FixedUpdate()
    {
        MoveHorizontal();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void MoveHorizontal()
    {
        // If player not running
        if (HorizontalInput == 0.0f)
        {
            PlayerRb2D.velocity = new Vector2(0.0f, PlayerRb2D.velocity.y); // Reset velocity
            return;
        }

        PlayerRb2D.velocity = new Vector2(HorizontalInput * playerSpeed, PlayerRb2D.velocity.y);
    }

    public void Jump()
    {
        // If out of jumps
        if (jumpsLeft <= 0)
        {
            return;
        }

        jumpsLeft--;
        IsGrounded = false;
        PlayerRb2D.velocity = new Vector2(PlayerRb2D.velocity.x, jumpPower);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Set on ground to true
        IsGrounded = true;

        // Reset remaining jumps
        jumpsLeft = MAXIMUM_NUMBER_JUMPS;

    }
}
