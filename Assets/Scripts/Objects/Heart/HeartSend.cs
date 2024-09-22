using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSend : MonoBehaviour
{
    private bool collected;
    private HeartAnimation heartAnimation;

    private void Start()
    {
        heartAnimation = transform.parent.GetComponentInChildren<HeartAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if collider is not player or heart is collected
        if (other.gameObject.name != "Player" || collected) return;

        // Send 1 heart to player succeed
        if (other.transform.GetComponentInChildren<DamageReceiver>().Add(1))
        {
            collected = true;
            // Play collected animation
            heartAnimation.PlayCollectedAnimation();
        }
    }
}
