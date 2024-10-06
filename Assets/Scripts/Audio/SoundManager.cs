using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class SoundManager : MonoBehaviour
{

    [SerializeField] protected List<AudioClip> clips;

    [SerializeField] protected AudioSource audioSource;

    [SerializeField] protected AudioMixer audioMixer;

    protected void Awake()
    {
        LoadComponents();
        LoadAudioClips();
        LoadAudioMixer();
    }

    private void LoadComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void LoadAudioMixer()
    {
        // Load one audio mixer
        AsyncOperationHandle<AudioMixer> handle = Addressables.LoadAssetAsync<AudioMixer>("Assets/Audio/AudioMixer/MainMixer.mixer");

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

    public void PlaySound(string name)
    {
        AudioClip clip = clips.Find(clip => clip.name == name);

        if (clip == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }

    protected abstract void LoadAudioClips();

    // Set initial volume from file
    protected abstract void InitialVolume();

}
