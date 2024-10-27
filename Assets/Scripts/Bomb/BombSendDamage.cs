using UnityEngine;

public class BombSendDamage : DamageSender
{
    private BombAnimation bombAnimation;
    private CircleCollider2D circleCollider2D;

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

        // Add force
        other.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(5.0f, 5.0f), ForceMode2D.Impulse);
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
