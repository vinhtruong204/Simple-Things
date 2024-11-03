using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class BaseVolumeSlider : BaseSlider
{
    [SerializeField] protected AudioMixer audioMixer;

    protected new void Awake()
    {
        LoadAudioMixer();
        base.Awake();
    }

    private void LoadAudioMixer()
    {
        // Load one audio mixer
        AsyncOperationHandle<AudioMixer> handle = Addressables.LoadAssetAsync<AudioMixer>("MainMixer");

        handle.Completed += Load_Completed;

    }

    private void Load_Completed(AsyncOperationHandle<AudioMixer> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Some assets could not loaded");
            return;
        }

        audioMixer = handle.Result;
        InitialVolume();
    }

    protected abstract void InitialVolume();
}