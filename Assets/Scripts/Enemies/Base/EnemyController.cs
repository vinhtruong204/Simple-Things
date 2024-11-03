using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyController : MonoBehaviour
{
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }
    public EnemyDamageSender EnemyDamageSender { get; private set; }
    public EnemyDetectPlayer EnemyDetectPlayer { get; private set; }

    public ManageEnemyNumbers ManageEnemyNumbers { get; private set; }

    private void Awake()
    {
        EnemyAnimation = GetComponentInChildren<EnemyAnimation>();
        EnemyMovement = GetComponentInChildren<EnemyMovement>();
        EnemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        EnemyDetectPlayer = GetComponentInChildren<EnemyDetectPlayer>();
        ManageEnemyNumbers = GetComponentInParent<ManageEnemyNumbers>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAnimation.OnCollisionStay2D(other);
    }
}
