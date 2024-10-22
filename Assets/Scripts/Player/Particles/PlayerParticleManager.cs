using UnityEngine;

public class PlayerParticleManager : MonoBehaviour
{
    private Animator animator;

    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;

    private Vector3 jumpParticlePosition = new();
    private Vector3 groundParticlePosition = new(0.0f, -0.5f);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = transform.parent.GetComponentInChildren<PlayerMovement>();
        playerAnimation = transform.parent.GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        PlayJumpAndFallParticle();

        PlayMoveParticle();

    }

    private void PlayJumpAndFallParticle()
    {
        if (!playerMovement.IsGrounded && !playerAnimation.IsJumping)
        {
            // Start jump
            animator.SetTrigger(PlayerString.PlayerParticleTrigger.JUMP);
            UpdatePosition(PlayerString.PlayerParticleTrigger.JUMP);
        }

        if (playerMovement.IsGrounded && playerAnimation.IsJumping)
        {
            // Fall to the ground
            animator.SetTrigger(PlayerString.PlayerParticleTrigger.GROUND);
            UpdatePosition(PlayerString.PlayerParticleTrigger.GROUND);
        }
    }

    private void PlayMoveParticle()
    {
        if (playerAnimation.IsJumping || playerMovement.HorizontalInput == 0.0f)
        {
            // Quit run particle
            animator.SetTrigger(PlayerString.PlayerParticleTrigger.END_RUN);
            return;
        }

        // Start play particle
        animator.SetTrigger(PlayerString.PlayerParticleTrigger.BEGIN_RUN);
        UpdatePosition(PlayerString.PlayerParticleTrigger.BEGIN_RUN);
    }

    // Update position based on current particle effect
    private void UpdatePosition(string particleName)
    {
        transform.position = particleName switch
        {
            PlayerString.PlayerParticleTrigger.JUMP => transform.parent.position + jumpParticlePosition,
            PlayerString.PlayerParticleTrigger.GROUND => transform.parent.position + groundParticlePosition,
            _ => transform.parent.position + GetRunParticlePosition(), // default
        };
    }

    private Vector3 GetRunParticlePosition()
    {
        Vector3 runParticlePosition = new(0, -0.5f)
        {
            // If the player is facing right
            x = transform.parent.localScale.x > 0.0f ? -0.5f : 0.5f
        };

        return runParticlePosition;
    }
}
