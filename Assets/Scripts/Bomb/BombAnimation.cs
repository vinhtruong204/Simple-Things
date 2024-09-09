using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnimation : MonoBehaviour
{
    private float time;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // private void OnEnable()
    // {
    //     time = 0.0f;
    //     animator.SetBool("Finished", false);
    // }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        SetupAnimationtype();

        if (time >= 5.0f)
            ResetTimer();
    }

    private void SetupAnimationtype()
    {
        animator.SetFloat("Time", time);
        if (time >= 5.0f)
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
        ObjectPool.Instance.Release(transform.parent.gameObject);
        // transform.parent.gameObject.SetActive(false);
    }
}
