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
        loadingPanel.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

}
