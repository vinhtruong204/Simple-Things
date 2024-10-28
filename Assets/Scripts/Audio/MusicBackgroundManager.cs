using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using System.Collections.Generic;

public class MusicBackgroundManager : SoundManager
{
    public static MusicBackgroundManager Instance { get; private set; }

    private new void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        base.Awake();
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    protected override void LoadAudioClips()
    {
        clips = new();

        AsyncOperationHandle<IList<AudioClip>> handle = Addressables.LoadAssetsAsync<AudioClip>(new List<string>() { "MusicBackground" },
        addressables =>
        {
            if (addressables != null)
            {
                clips.Add(addressables);
            }
        },
        Addressables.MergeMode.Union,
        false);

        handle.Completed += Load_Completed;
    }

    private void Load_Completed(AsyncOperationHandle<IList<AudioClip>> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Music background could not loaded!");
            return;
        }

        PlaySound(AudioString.MusicString.NAME_MUSIC_BACKGROUND);
    }

    protected override void InitialVolume()
    {
        float value = PlayerPrefs.GetFloat(AudioString.MusicString.MUSIC_VOLUME);
        audioMixer.SetFloat(AudioString.MusicString.MUSIC_VOLUME, Mathf.Log10(value) * 20);
    }
}
