using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}