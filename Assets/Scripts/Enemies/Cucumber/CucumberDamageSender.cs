using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberDamageSender : DamgeSender
{
    private CucumberAnimation cucumberAnimation;

    private void Awake()
    {
        cucumberAnimation = transform.parent.GetComponent<CucumberAnimation>();
        amount = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cucumberAnimation != null && cucumberAnimation.AttackSucceed)
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
