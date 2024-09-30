using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : BaseButton
{
    [SerializeField] private GameObject helpPanel;

    private void Start()
    {
        helpPanel = transform.parent.parent.GetChild(2).gameObject;

        // parent: Main Menu -> parent: Canvas -> GetChild(2): Help panel
    }

    protected override void OnClick()
    {
        // Disable main menu
        transform.parent.gameObject.SetActive(false);

        // Enable help panel
        helpPanel.SetActive(true);
    }
}
