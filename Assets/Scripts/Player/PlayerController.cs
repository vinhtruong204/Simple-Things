using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }

    private void Start()
    {
        PlayerMovement = GetComponentInChildren<PlayerMovement>();
        PlayerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement.OnTriggerEnter2D(other);
    }
}
