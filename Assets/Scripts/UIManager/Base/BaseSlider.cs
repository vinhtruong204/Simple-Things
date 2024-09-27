using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : MonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected void Awake()
    {
        LoadSlider();

        AddOnValueChangeEvent();
    }

    private void LoadSlider()
    {
        slider = GetComponent<Slider>();
    }


    private void AddOnValueChangeEvent()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    protected abstract void OnValueChanged(float value);
}
