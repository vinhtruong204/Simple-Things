using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAnimation : MonoBehaviour, IDamageAnimation, IAddAnimationEvent
{
    // Animation control
    private Animator animator;

    // Relate direction and type of animation
    private PlayerMovement playerMovement;
    private Vector3 scale;

    // Get rigidbody 2d
    private Rigidbody2D playerRb2D;

    // Hit handle
    private PlayerDamageReceiver playerDamageReceiver;

    // Jumping
    private bool isJumping;

    private void Start()
    {
        GetAllComponents();

        AddAnimationEvent();
    }

    private void GetAllComponents()
    {
        animator = GetComponent<Animator>();
        playerMovement = transform.parent.GetComponentInChildren<PlayerMovement>();
        playerDamageReceiver = transform.parent.GetComponentInChildren<PlayerDamageReceiver>();
        playerRb2D = GetComponentInParent<Rigidbody2D>();
        scale = transform.parent.localScale;
    }

    public void AddAnimationEvent()
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            AnimationEvent aniEvent = new()
            {
                time = clip.length
            };

            switch (clip.name)
            {
                case "Hit":
                    aniEvent.functionName = nameof(HitFinished);
                    break;
                case "Dead Ground":
                    aniEvent.functionName = nameof(DeadGroundFinished);
                    break;
                default:
                    continue;
            }

            clip.AddEvent(aniEvent);
        }

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
        // If player is deaded
        if (playerDamageReceiver.IsDead) return;

        // Set animation animation style depend on current character statesF
        if (!playerMovement.IsGrounded && !isJumping)
        {
            animator.SetTrigger(PlayerString.PlayerAnimationParameters.IS_JUMPING);
            isJumping = true;

            // Play sound
            SoundFXManager.Instance.PlaySound(AudioString.SoundString.JUMP);
        }

        if (playerMovement.IsGrounded && isJumping)
        {
            animator.SetTrigger(PlayerString.PlayerAnimationParameters.IS_GROUND);
            isJumping = false;
        }

        animator.SetFloat(PlayerString.PlayerAnimationParameters.MOVE_X,
        Mathf.Abs(playerRb2D.velocity.x));

        animator.SetFloat(PlayerString.PlayerAnimationParameters.MOVE_Y,
        playerRb2D.velocity.y);
    }

    public void PlayHitAnimation()
    {
        animator.SetTrigger(PlayerString.PlayerAnimationParameters.IS_BEING_HIT);
    }

    public void HitFinished()
    {
        playerDamageReceiver.ResetIsBeingHit();
    }

    public void PlayDeadHitAnimation()
    {
        animator.SetTrigger(PlayerString.PlayerAnimationParameters.DEAD_HIT);
    }

    public void DeadGroundFinished()
    {
        Debug.Log("player deaded");
    }

}
