using System;
using System.Collections;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public static LoadLevel Instance { get; private set; }
    private const int TOTAL_LEVEL = 2;
    public Slider slider;
    public TMP_Text percentText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
        // DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex == 0) return;

        if (ManageUser.Instance.StartMode.Contains("Host"))
        {
            NetworkManager.Singleton.StartHost();
        }
        else
        {
            NetworkManager.Singleton.StartClient();
        }

    }

    public void LoadNextLevel()
    {
        // Calculate next level
        int nextLevelBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // If next level exceeds max level
        if (nextLevelBuildIndex > TOTAL_LEVEL)
        {
            // Load menu scene
            nextLevelBuildIndex = 0;
        }

        // Shutdown network manager
        NetworkManager.Singleton.Shutdown();

        // Start load scene asynchronously
        StartCoroutine(LoadSceneAsynchronously(nextLevelBuildIndex));
    }

    private IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            // progress: 0.9 -- loading
            //           0.1 -- active
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            percentText.text = Math.Round(progress * 100.0f, 2) + " %";
            yield return null;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
