using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implement when player receive damage
public interface IDamageAnimation
{
    public void PlayHitAnimation();
    public void HitFinished();
    public void PlayDeadHitAnimation();
    public void DeadGroundFinished();
}
