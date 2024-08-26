using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables relate player movement
    private Rigidbody2D playerRb2D;
    private float playerSpeed = 5.0f;

    // Variables relate user input
    private float verticalInput, horizontalInput;
    // Start is called before the first frame update
    private void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void GetUserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector2 movement = new Vector2(horizontalInput, 0.0f).normalized * playerSpeed;
        playerRb2D.velocity = movement;
    }
}
