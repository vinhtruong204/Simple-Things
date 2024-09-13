using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSendDamage : DamgeSender
{
    private BombAnimation bombAnimation;
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        LoadAllComponents();

        amount = 1; // Initial amount damage
    }

    private void LoadAllComponents()
    {
        bombAnimation = BombController.Instance.BombAnimation;
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        DisableCollider();
    }

    private void FixedUpdate()
    {
        if (bombAnimation.IsExploded)
        {
            circleCollider2D.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    public void DisableCollider()
    {
        // Prevent null reference exception when instantiate
        if (circleCollider2D == null) return;

        circleCollider2D.enabled = false;
    }
}