using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSlider : BaseVolumeSlider
{
    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(AudioString.MusicString.MUSIC_VOLUME, 1.0f);
    }

    protected override void OnValueChanged(float value)
    {
        audioMixer.SetFloat(AudioString.MusicString.MUSIC_VOLUME, Mathf.Log10(value) * 20);

        // Save music volume
        PlayerPrefs.SetFloat(AudioString.MusicString.MUSIC_VOLUME, value);
    }
}
