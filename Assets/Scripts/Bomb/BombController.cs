using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public static BombController Instance { get; private set; }
    public BombAnimation BombAnimation { get; private set; }
    public BombForce BombForce { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BombAnimation = GetComponentInChildren<BombAnimation>();
        BombForce = GetComponentInChildren<BombForce>();
    }
}
