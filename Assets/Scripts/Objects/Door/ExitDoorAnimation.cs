using UnityEngine;

public class ExitDoorAnimation : MonoBehaviour, IAddAnimationEvent
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator = GetComponent<Animator>();
        AddAnimationEvent();
    }

    public void AddAnimationEvent()
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name != "Closed") continue;

            AnimationEvent aniEvent = new()
            {
                time = clip.length,
                functionName = nameof(CompletedClosedDoor)
            };

            clip.AddEvent(aniEvent);
        }
    }

    // Handle animation when win the game
    public void OpenExitDoor()
    {
        animator.SetTrigger("Open");
    }

    private void CompletedClosedDoor()
    {
        GameStatesManager.Instance.HandleGameWin();
    }
}
