using System;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private GameObject player;

    private readonly float visionRange = 5.0f;

    // Offset prevent raycast start inside box collider
    private Vector3 offset = new(-0.5f, 0f);

    public bool PlayerDetected { get; private set; }

    private void Start()
    {
        player = GameObjectManager.Instance.Player;
    }

    private void Update()
    {

        // Check the distance

        if (PlayerInRange())
        {
            // Check angle
            if (PlayerInHorizontalSight())
            {
                // Calculate offset and start ray cast

                Vector2 rayOrigin;
                // Player in the left
                if (PlayerOnTheLeft())
                {
                    rayOrigin = transform.parent.position + new Vector3(-0.5f, 0, 0);
                }
                else
                {
                    rayOrigin = transform.parent.position + new Vector3(0.5f, 0, 0);
                }

                RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, GetDirection(), visionRange, LayerMask.GetMask("Obstacle", "ReceiveDamage"));
                Debug.DrawRay(rayOrigin, GetDirection() * visionRange, Color.white);

                if (raycastHit2D.collider != null)
                {
                    Debug.Log(raycastHit2D.transform.gameObject.name);
                }
            }

            // Debug.Log("i can see you");
        }

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