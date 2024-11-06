using UnityEngine;

public class GameStatesManager : MonoBehaviour
{
    public static GameStatesManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;

    // If total enemy is 0 and player hit the exit door
    [SerializeField] private GameObject gameWinPanel;

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

    public void HandleGameWin()
    {
        gameWinPanel.SetActive(true);
        LoadLevel.Instance.LoadNextLevel();
        //
    }
}
