using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberAnimation : CucumberController
{
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        cucumberMovement = transform.parent.GetComponentInChildren<CucumberMovement>();
    }

    public void Flip()
    {
        // Get parent game object scale
        Vector3 scale = transform.parent.localScale;

        // Flip horizontal
        scale.x *= -1.0f;

        // Set new parent game object scale
        transform.parent.localScale = scale;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            animator.SetBool("IsAttacking", true);
    }

    public void AttackFinished()
    {
        animator.SetBool("IsAttacking", false);
    }
}
