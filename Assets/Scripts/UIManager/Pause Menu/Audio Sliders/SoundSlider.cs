using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlider : BaseVolumeSlider
{

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(AudioString.SoundString.SOUND_VOLUME, 1.0f);
    }

    protected override void OnValueChanged(float value)
    {
        audioMixer.SetFloat(AudioString.SoundString.SOUND_VOLUME, Mathf.Log10(value) * 20);

        // Save sound volume
        PlayerPrefs.SetFloat(AudioString.SoundString.SOUND_VOLUME, value);
    }
}
