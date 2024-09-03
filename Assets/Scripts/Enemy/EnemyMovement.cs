using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 2.0f;
    private Rigidbody2D enemyRb;
    private bool isChangingDirection = false;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isChangingDirection = false;
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        Vector2 velocity = enemyRb.velocity;
        if (IsFacingRight())
        {
            velocity.x = enemySpeed;
        }
        else
        {
            velocity.x = -enemySpeed;
        }

        enemyRb.velocity = velocity;
    }

    private bool IsFacingRight()
    {
        return transform.parent.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isChangingDirection) return;
        isChangingDirection = true;
        Vector3 scale = transform.parent.localScale;
        scale.x *= -1.0f;
        transform.parent.localScale = scale;

    }
}
