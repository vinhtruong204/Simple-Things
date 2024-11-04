using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button button;

    protected void Awake()
    {
        LoadButton();

        AddOnClickEvent();
    }

    private void LoadButton()
    {
        button = GetComponent<Button>();
    }

    private void AddOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
