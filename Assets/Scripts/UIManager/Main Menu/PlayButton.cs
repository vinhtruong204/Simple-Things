using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayButton : BaseButton
{
    public Slider slider;
    public TMP_Text percentText;
    private new void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        base.Awake();
    }
    protected override void OnClick()
    {
        StartCoroutine(LoadSceneAsynchronously(1));
    }

    IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            percentText.text = progress * 100.0f + "%";

            yield return null;
        }
    }
}
