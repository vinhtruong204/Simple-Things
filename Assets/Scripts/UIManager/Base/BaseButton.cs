using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button button;

    // Start is called before the first frame update
    protected void Start()
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
