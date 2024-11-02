using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyDetectPlayer : MonoBehaviour
{
    private GameObject player;

    public EnemyDetectPlayerSO enemyDetectPlayerSO;
    private float visionRange;

    // Offset prevent raycast start inside box collider
    protected Vector3 offsetLeft;
    protected Vector3 offsetRight;


    public bool PlayerDetected { get; private set; }

    private void Start()
    {
        player = GameObjectManager.Instance.Player;

        LoadScriptableObject();
    }

    private void LoadScriptableObject()
    {
        Addressables.LoadAssetAsync<EnemyDetectPlayerSO>(transform.parent.name)
        .Completed += (handle) =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("Could not load enemy detect player SO:" + transform.parent.name);
                return;
            }

            // Get enemy detect player SO
            enemyDetectPlayerSO = handle.Result;

            // Initialize the corresponding values
            visionRange = enemyDetectPlayerSO.visionRange;
            offsetLeft = enemyDetectPlayerSO.offsetLeft;
            offsetRight = enemyDetectPlayerSO.offsetRight;
        };
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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, GetDirection(), visionRange, LayerMask.GetMask("Obstacle", "Enemy", "Player"));

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
        return (0.0f <= angle && angle <= 10.0f) || (170.0f <= angle && angle <= 180.0f);
    }

    private Vector2 GetDirection()
    {
        return (player.transform.position - transform.parent.position).normalized;
    }

}