using UnityEngine;

public class BombForce : MonoBehaviour
{
    private Rigidbody2D bombRb;

    private GameObject player;

    private readonly float magnitudeForce = 6.0f;

    private void Awake()
    {
        bombRb = GetComponentInParent<Rigidbody2D>();
        player = GameObjectManager.Instance.Player;
    }

    private void OnEnable()
    {
        SetPosition();

        AddForceToBomb();
    }

    private void SetPosition()
    {
        transform.parent.position = player.transform.position;
    }

    private void AddForceToBomb()
    {
        if (IsPlayerFacingRight())
        {
            bombRb.AddForce(Vector2.right * magnitudeForce, ForceMode2D.Impulse);
        }
        else
        {
            bombRb.AddForce(Vector2.left * magnitudeForce, ForceMode2D.Impulse);
        }
    }

    private bool IsPlayerFacingRight()
    {
        return player.transform.localScale.x > Mathf.Epsilon; // x > 0.0001f
    }
}
