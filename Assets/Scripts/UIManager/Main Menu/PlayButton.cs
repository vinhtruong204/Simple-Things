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
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 60;
        base.Awake();
    }
    protected override void OnClick()
    {
        // Delete current health point when play again
        PlayerPrefs.DeleteKey("CurrentHP");

        // Enable loading panel and reset time scale to 1f
        loadingPanel.SetActive(true);
        LoadLevel.Instance.LoadNextLevel();
        
        // Update time scale
        Time.timeScale = 1.0f;

        // Disable main menu buttons
        transform.parent.gameObject.SetActive(false);
    }

}
