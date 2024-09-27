using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

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

    private void Start()
    {
        PlaySound("ThemeSong");
    }

    protected override void LoadAudioClips()
    {
        string[] guids = AssetDatabase.FindAssets("t:AudioClip",
                            new string[] { "Assets/Audio/MusicBackground" });

        clips = new AudioClip[guids.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            clips[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(
                AssetDatabase.GUIDToAssetPath(guids[i]));
        }
    }
}
