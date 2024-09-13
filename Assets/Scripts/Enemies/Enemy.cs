using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy movement")]
    protected float enemySpeed = 1.5f;
    protected Rigidbody2D enemyRb;

    [Header("Enemy animation")]
    protected Animator animator;
    // Prevent player change direction twice and get stuck in the wall
    protected bool isChangingDirection = false;

}
