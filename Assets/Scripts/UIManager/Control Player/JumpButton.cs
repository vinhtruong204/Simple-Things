using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : BaseButton, IHandleLoadedPlayer
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        Invoke(nameof(HandleLoadedPlayer), 1f);
    }

    public void HandleLoadedPlayer()
    {
        playerMovement = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerMovement>();
    }

    protected override void OnClick()
    {
        playerMovement.Jump();
    }
}
