using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombForce : MonoBehaviour
{
    private Rigidbody2D bombRb;

    private GameObject player;

    private bool isPlayerFacingRight;

    private Vector3 offsetRight = new(1.0f, 0.5f, 0.0f);
    private Vector3 offsetLeft = new(-1.0f, 0.5f, 0.0f);

    private readonly float magnitudeForce = 5.0f;

    private void Awake()
    {
        bombRb = GetComponentInParent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        SetPlayerDirection();

        SetPosition();

        AddForceToBomb();

    }

    private void SetPlayerDirection()
    {
        isPlayerFacingRight = player.transform.localScale.x > Mathf.Epsilon; // x > 0.0001f
    }

    private void SetPosition()
    {
        if (isPlayerFacingRight)
        {
            transform.parent.position = player.transform.position + offsetRight;
        }
        else
        {
            transform.parent.position = player.transform.position + offsetLeft;
        }
    }

    private void AddForceToBomb()
    {
        if (isPlayerFacingRight)
        {
            bombRb.AddForce(Vector2.right * magnitudeForce, ForceMode2D.Impulse);
        }
        else
        {
            bombRb.AddForce(Vector2.left * magnitudeForce, ForceMode2D.Impulse);
        }
    }
}
