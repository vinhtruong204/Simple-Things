using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager Instance { get; private set; }

    public GameObject Player { get; private set; }

    public GameObject Enemies { get; private set; }

    private void LoadPlayer(GameObject playerObj)
    {
        Player = playerObj;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        // Player = GameObject.Find("Player");

        PlayerController.OnPlayerSpawned += LoadPlayer;
        Enemies = GameObject.Find("Enemies");
        //DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerSpawned -= LoadPlayer;
    }
}