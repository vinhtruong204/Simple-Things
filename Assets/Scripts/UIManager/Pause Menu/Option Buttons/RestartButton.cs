using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : BaseButton
{
    protected override void OnClick()
    {
        // Delete current health point when play again
        PlayerPrefs.DeleteKey("CurrentHP");

        // Load level 1
        SceneManager.LoadScene(1);

        // Update time scale
        Time.timeScale = 1.0f;
    }
}
