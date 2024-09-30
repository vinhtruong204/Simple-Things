using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : BaseButton
{
    private PlayerThrowBomb playerThrowBomb;

    private void Start()
    {
        playerThrowBomb = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerThrowBomb>();
    }

    protected override void OnClick()
    {
        playerThrowBomb.ThrowBomb();
    }
}
