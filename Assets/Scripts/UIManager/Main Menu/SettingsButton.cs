using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : BaseButton
{
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        // Get game object by index because can't find inactive game object by tag or name
        settingsPanel = transform.parent.parent.GetChild(1).gameObject;

        // parent: Main menu -> parent: Canvas -> GetChild(1): Settings Panel
    }

    protected override void OnClick()
    {
        // Disable main menu buttons
        transform.parent.gameObject.SetActive(false);

        // Set active for the settings panel
        settingsPanel.SetActive(true);
    }
}
