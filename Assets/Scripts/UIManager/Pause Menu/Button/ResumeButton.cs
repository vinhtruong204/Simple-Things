using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : BaseButton
{
    [SerializeField] private GameObject pauseMenu;

    private new void Start()
    {
        base.Start();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    protected override void OnClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
