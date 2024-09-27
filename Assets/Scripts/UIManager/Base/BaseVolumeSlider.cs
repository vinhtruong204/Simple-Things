using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public abstract class BaseVolumeSlider : BaseSlider
{
    [SerializeField] protected AudioMixer audioMixer;

    protected new void Awake()
    {
        base.Awake();
        LoadAudioMixer();
    }

    private void LoadAudioMixer()
    {
        // Get gobal unique identity string
        string[] guids = AssetDatabase.FindAssets("t:AudioMixer", new string[] { "Assets/Audio/AudioMixer" });

        // There is only one path to the main audio mixer file
        audioMixer = AssetDatabase.LoadAssetAtPath<AudioMixer>(AssetDatabase.GUIDToAssetPath(guids[0]));

    }
}