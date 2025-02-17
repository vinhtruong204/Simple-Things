using UnityEngine;

public class BombForce : MonoBehaviour, IHandleLoadedPlayer
{
    private Rigidbody2D bombRb;

    private GameObject player;

    private readonly float magnitudeForce = 6.0f;

    private void Awake()
    {
        bombRb = GetComponentInParent<Rigidbody2D>();
        player = GameObjectManager.Instance.Player;
        if (player == null)
        {
            Invoke(nameof(HandleLoadedPlayer), 1f);
        }
    }

    public void HandleLoadedPlayer()
    {
        player = GameObjectManager.Instance.Player;
        SetPosition();

        AddForceToBomb();
    }

    private void OnEnable()
    {
        if (player == null) return;
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
