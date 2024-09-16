using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : MonoBehaviour
{
    public CucumberMovement CucumberMovement { get; private set; }
    public CucumberAnimation CucumberAnimation { get; private set; }

    private void Start()
    {
        CucumberAnimation = GetComponentInChildren<CucumberAnimation>();
        CucumberMovement = GetComponentInChildren<CucumberMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CucumberAnimation.OnCollisionEnter2D(other);
    }
}
