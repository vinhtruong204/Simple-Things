using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : BaseButton, IHandleLoadedPlayer
{
    private PlayerThrowBomb playerThrowBomb;

    private void Start()
    {
        Invoke(nameof(HandleLoadedPlayer), 1f);
    }

    public void HandleLoadedPlayer()
    {
        playerThrowBomb = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerThrowBomb>();
    }

    protected override void OnClick()
    {
        playerThrowBomb?.ThrowBomb();
    }
}
