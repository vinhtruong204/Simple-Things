using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSlider : BaseVolumeSlider
{
    protected override void OnValueChanged(float value)
    {
        audioMixer.SetFloat(AudioString.MusicString.MUSIC_VOLUME, Mathf.Log10(value) * 20);
    }
}
