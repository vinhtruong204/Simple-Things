using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    private const int TOTAL_LEVEL = 1;
    public static LoadScene Instance { get; private set; }
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
        // DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        int nextLevelBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevelBuildIndex > TOTAL_LEVEL)
        {
            nextLevelBuildIndex = 0;
        }

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
}
