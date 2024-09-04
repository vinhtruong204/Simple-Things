using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : Enemy
{
    public static CucumberController Instance { get; private set; }

    public CucumberMovement CucumberMovement { get; private set; }
    public CucumberAnimation CucumberAnimation { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Only one instance Enemy Controller is accepted!");
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        CucumberMovement = GetComponentInChildren<CucumberMovement>();
        CucumberAnimation = GetComponentInChildren<CucumberAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CucumberAnimation.OnCollisionEnter2D(other);
    }
}
