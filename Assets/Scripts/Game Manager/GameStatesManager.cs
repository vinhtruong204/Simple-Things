using UnityEngine;

public class GameStatesManager : MonoBehaviour
{
    // If total enemy is 0 and player hit the exit door
    public static GameStatesManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(transform.parent.gameObject);
    }

    public void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
