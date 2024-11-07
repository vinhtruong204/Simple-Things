using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : BaseButton
{
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        // pauseMenu = transform.parent.GetChild(3).gameObject;
        // pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }

    protected override void OnClick()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }
}
