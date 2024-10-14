using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public TMP_Text percentText;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadSceneAsynchronously(1));
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
