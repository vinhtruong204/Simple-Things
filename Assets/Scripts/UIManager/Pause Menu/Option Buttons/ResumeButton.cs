using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : BaseButton
{
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag(GameObjectString.GameObjectTag.PAUSE_MENU_TAG);
    }

    protected override void OnClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
