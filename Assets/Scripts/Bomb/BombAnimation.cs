using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    private readonly float explosionTime = 3.0f;
    private float time;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        SetupAnimationtype();

        if (time >= explosionTime)
            ResetTimer();
    }

    private void SetupAnimationtype()
    {
        animator.SetFloat("Time", time);
        if (time >= explosionTime)
            animator.SetBool("Finished", true);

    }

    private void UpdateTimer()
    {
        time += Time.deltaTime;
    }

    private void ResetTimer()
    {
        time = 0.0f;
    }

    public void BooomFinished()
    {
        BombSpawner.Instance.DeSpawnObject(transform.parent.gameObject);
    }
}
