using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    private readonly float explosionTime = 3.0f;
    private float timer;
    private Animator animator;
    public bool IsExploded { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        IsExploded = false; // Reset bool
        timer = 0.0f; // Reset timer
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTimer();

        SetAnimationType();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    private void SetAnimationType()
    {
        animator.SetFloat(BombString.BombAnimationParameter.TIME, timer);

        if (timer >= explosionTime)
        {
            IsExploded = true;
            animator.SetBool(BombString.BombAnimationParameter.FINISHED, IsExploded); // Start run boom animation

            // Play exploded sound
            SoundFXManager.Instance.PlaySound(AudioString.SoundString.EXPLODED);
        }
    }

    // Method add to unity event when last frame of animation boom finished
    public void BooomFinished()
    {
        IsExploded = false;
        BombSpawner.Instance.DeSpawnObject(transform.parent.gameObject);
    }
}
