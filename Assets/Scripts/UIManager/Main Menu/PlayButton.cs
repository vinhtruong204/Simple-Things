using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayButton : BaseButton
{
    public GameObject loadingPanel;
    
    private new void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        base.Awake();
    }
    protected override void OnClick()
    {
        // Enable loading panel and reset time scale to 1f
        loadingPanel.SetActive(true);
        LoadLevel.Instance.LoadNextLevel();
        Time.timeScale = 1.0f;

        // Disable main menu buttons
        transform.parent.gameObject.SetActive(false);
    }

}
