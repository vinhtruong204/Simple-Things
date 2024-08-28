using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        playerMovement = PlayerController.Instance.PlayerMovement;
        animator.SetBool("IsRunning", playerMovement.IsRunning);
    }
}
