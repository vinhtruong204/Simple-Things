using System;
using UnityEngine;

public class ManageEnemyNumbers : MonoBehaviour
{
    public int TotalEnemyCount { get; private set; }

    private void Awake()
    {
        // Get total enemy of current scene
        TotalEnemyCount = transform.childCount;
    }

    private void Update()
    {
        UpdateEnemyCount();
    }

    private void UpdateEnemyCount()
    {
        TotalEnemyCount = transform.childCount;
    }
}
