using System;
using UnityEngine;

public class BombSendDamage : DamageSender
{
    private BombAnimation bombAnimation;
    private CircleCollider2D circleCollider2D;
    private Vector2 rightForce = new(6.0f, 6.0f);
    private Vector2 leftForce = new(-6.0f, 6.0f);

    private void Awake()
    {
        LoadAllComponents();
        InitialAmountDamage();
    }

    private void LoadAllComponents()
    {
        bombAnimation = transform.parent.GetComponentInChildren<BombAnimation>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        DisableCollider();
    }

    private void Update()
    {
        CheckExploded();
    }

    private void CheckExploded()
    {
        if (bombAnimation.IsExploded)
        {
            circleCollider2D.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);
        SendDamage(other.transform);

        // Check if other components have rigidbody2D
        AddForce(other);
    }

    private void AddForce(Collider2D other)
    {
        if (!other.transform.TryGetComponent(out Rigidbody2D rb2D)) return;

        // Collider on the left
        if (other.transform.position.x < transform.parent.position.x)
        {
            // Push a force to the right
            rb2D.AddForce(rightForce, ForceMode2D.Impulse);
        }

        // Collider on the right
        else
        {
            // Push a force to the left
            rb2D.AddForce(leftForce, ForceMode2D.Impulse);
        }

    }

    private void DisableCollider()
    {
        // Prevent null reference exception when instantiate
        if (circleCollider2D == null) return;

        circleCollider2D.enabled = false;
    }

    protected override void InitialAmountDamage()
    {
        amount = 1; // Initial amount damage
    }
}
