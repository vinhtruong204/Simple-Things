using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private float time;
    private bool finished;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        time = 0.0f;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateTimer();

        SetupAnimationtype();
    }

    private void SetupAnimationtype()
    {
        animator.SetFloat("Time", time);
        if (time >= 5.0f)
        {
            finished = true;
            animator.SetBool("Finished", finished);
        }
    }

    private void UpdateTimer()
    {
        time += Time.deltaTime;
    }

    public void BooomFinished()
    {
        animator.SetBool("Finished", false);
        ObjectPool.Instance.Release(transform.parent.gameObject);
        // transform.parent.gameObject.SetActive(false);
    }
}
