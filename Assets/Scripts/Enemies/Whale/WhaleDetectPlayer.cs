using UnityEngine;
public class WhaleDetectPlayer : EnemyDetectPlayer
{
    private void Awake()
    {
        offsetLeft = new(-1.5f, 0f);
        offsetRight = new(1.5f, 0f);
    }
}