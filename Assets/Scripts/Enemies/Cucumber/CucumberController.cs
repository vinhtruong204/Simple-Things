using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : Enemy
{
    protected CucumberMovement cucumberMovement;
    protected CucumberAnimation cucumberAnimation;

    private void Start()
    {
        cucumberAnimation = GetComponentInChildren<CucumberAnimation>();
        cucumberMovement = GetComponentInChildren<CucumberMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        cucumberAnimation.OnCollisionEnter2D(other);
    }
}
