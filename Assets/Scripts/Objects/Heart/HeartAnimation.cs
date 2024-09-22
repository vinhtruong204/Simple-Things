using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayCollectedAnimation()
    {
        animator.SetTrigger("Collected");
    }

    public void CollectedFinished()
    {
        Destroy(gameObject);
    }
}
