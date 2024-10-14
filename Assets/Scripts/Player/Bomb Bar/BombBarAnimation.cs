using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarAnimation : MonoBehaviour, IAddAnimationEvent
{
    private Animator animator;
    public bool CanThrowBomb { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        AddAnimationEvent();
    }

    private void OnEnable()
    {
        CanThrowBomb = false;
    }

    public void AddAnimationEvent()
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "Closing")
            {
                AnimationEvent closeEvent = new()
                {
                    time = clip.length,
                    functionName = nameof(DisableGameObject)
                };

                clip.AddEvent(closeEvent);
            }
        }
    }

    public void DisableGameObject()
    {
        CanThrowBomb = true;
        gameObject.SetActive(false);
    }
}
