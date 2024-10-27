using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }
    public EnemyDamageSender EnemyDamageSender { get; private set; }
    public EnemyDetectPlayer EnemyDetectPlayer { get; private set; }

    public CharacterSO EnemySO { get; private set; }

    private void Awake()
    {
        EnemyAnimation = GetComponentInChildren<EnemyAnimation>();
        EnemyMovement = GetComponentInChildren<EnemyMovement>();
        EnemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        EnemyDetectPlayer = GetComponentInChildren<EnemyDetectPlayer>();
        EnemySO = Resources.Load<CharacterSO>("Enemy/" + gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAnimation.OnCollisionStay2D(other);
    }
}
