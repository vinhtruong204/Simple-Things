using System;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    private GameObject player;

    private readonly float visionRange = 5.0f;

    // Offset prevent raycast start inside box collider
    private Vector3 offsetLeft = new(-0.5f, 0f);
    private Vector3 offsetRight = new(0.5f, 0f);

    public bool PlayerDetected { get; private set; }

    private void Start()
    {
        player = GameObjectManager.Instance.Player;
    }

    private void Update()
    {
        UpdatePlayerDetected();
    }

    private void UpdatePlayerDetected()
    {
        if (!PlayerInRange() || !PlayerInHorizontalSight())
        {
            PlayerDetected = false;
            return;
        }

        // Calculate start point of raycast
        Vector2 rayOrigin = GetRaycastStartPosition();

        // Fire a ray
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, GetDirection(), visionRange, LayerMask.GetMask("Obstacle", "ReceiveDamage"));

        // Test ray
        Debug.DrawRay(rayOrigin, GetDirection() * visionRange, Color.white);

        // If raycast don't hit a collider or collider is not from player
        if (raycastHit2D.collider == null || raycastHit2D.transform.gameObject.name != GameObjectString.GameObjectName.PLAYER_NAME)
        {
            PlayerDetected = false;
            return;
        }

        // Enemy can see the player
        PlayerDetected = true;
    }

    private Vector2 GetRaycastStartPosition()
    {
        return PlayerOnTheLeft() ? transform.parent.position + offsetLeft : transform.parent.position + offsetRight;
    }

    private bool PlayerOnTheLeft()
    {
        return transform.parent.position.x > player.transform.position.x;
    }

    private bool PlayerInRange()
    {
        return Vector2.Distance(transform.position, player.transform.position) < visionRange;
    }

    private bool PlayerInHorizontalSight()
    {
        float angle = Vector2.Angle(Vector2.right, GetDirection());
        return (0.0f <= angle && angle <= 20.0f) || (160.0f <= angle && angle <= 180.0f);
    }

    private Vector2 GetDirection()
    {
        return (player.transform.position - transform.parent.position).normalized;
    }

}