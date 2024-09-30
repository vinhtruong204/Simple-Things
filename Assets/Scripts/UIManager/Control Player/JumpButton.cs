using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : BaseButton
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerMovement>();
    }

    protected override void OnClick()
    {
        playerMovement.Jump();
    }
}
