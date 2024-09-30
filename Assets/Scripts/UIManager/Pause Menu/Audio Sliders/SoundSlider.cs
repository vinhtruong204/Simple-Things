using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlider : BaseVolumeSlider
{
    protected override void OnValueChanged(float value)
    {
        audioMixer.SetFloat(AudioString.SoundString.SOUND_VOLUME, Mathf.Log10(value) * 20);
    }
}
