using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : BaseButton
{
    [SerializeField] private GameObject pauseMenu;

    private new void Start()
    {
        base.Start();
        pauseMenu = transform.parent.GetChild(2).gameObject;
        // pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    protected override void OnClick()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }
}
