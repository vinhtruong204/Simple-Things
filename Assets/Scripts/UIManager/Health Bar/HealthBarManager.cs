using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;

    private PlayerDamageReceiver playerDamageReceiver;

    private void Start()
    {
        hearts = GameObject.FindGameObjectsWithTag(GameObjectString.GameObjectTag.HEART_TAG);

        playerDamageReceiver = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerDamageReceiver>();
    }

    // Update UI after add heart. Prevent out of index in array hearts
    private void LateUpdate()
    {
        SetActiveHearts();

        SetInActiveHearts();
    }

    private void SetActiveHearts()
    {
        for (int i = 0; i < playerDamageReceiver.CurrentHP; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    private void SetInActiveHearts()
    {
        for (int i = playerDamageReceiver.CurrentHP; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
    }
}
