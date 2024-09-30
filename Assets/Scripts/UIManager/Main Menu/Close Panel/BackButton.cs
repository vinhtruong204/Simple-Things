using UnityEngine;

public class BackButton : BaseButton
{
    [SerializeField] private GameObject mainMenu;

    private void Start()
    {
        mainMenu = transform.parent.parent.GetChild(0).gameObject;

        // parent: Settings Panel -> parent: Canvas -> GetChild(0): Main Menu
    }

    protected override void OnClick()
    {
        // Disable settings panel
        transform.parent.gameObject.SetActive(false);

        // Enable main menu
        mainMenu.SetActive(true);
    }
}