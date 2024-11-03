using UnityEngine;

public class ExitDoorHandleGameWin : MonoBehaviour
{
    private ManageEnemyNumbers manageEnemyNumbers;
    private ExitDoorAnimation exitDoorAnimation;
    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        exitDoorAnimation = GetComponent<ExitDoorAnimation>();
    }

    private void Start()
    {
        // Get component contain enemy numbers when start game
        manageEnemyNumbers = GameObjectManager.Instance.Enemies.GetComponent<ManageEnemyNumbers>();
        playerAnimation = GameObjectManager.Instance.Player.GetComponentInChildren<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check enemy count when player hit the collider
        if (manageEnemyNumbers.TotalEnemyCount > 0) return;

        // If the player collides with the door
        if (other.gameObject.name == "Player")
        {
            playerAnimation.PlayDoorInAnimation();
            exitDoorAnimation.OpenExitDoor();
        }
    }
}
