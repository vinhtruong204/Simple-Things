using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : MonoBehaviour
{
    public CucumberMovement CucumberMovement { get; private set; }
    public CucumberAnimation CucumberAnimation { get; private set; }
    public CucumberDamageSender CucumberDamageSender { get; private set; }

    private void Awake()
    {
        CucumberAnimation = GetComponentInChildren<CucumberAnimation>();
        CucumberMovement = GetComponentInChildren<CucumberMovement>();
        CucumberDamageSender = GetComponentInChildren<CucumberDamageSender>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        CucumberAnimation.OnCollisionStay2D(other);
    }
}
