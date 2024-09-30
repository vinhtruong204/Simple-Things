using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFXManager : SoundManager
{
    public static SoundFXManager Instance { get; private set; }

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound(AudioString.SoundString.COLLECTED);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound(AudioString.SoundString.ENEMY_ATTACK);
        }
    }

    protected override void LoadAudioClips()
    {
        string[] guids = AssetDatabase.FindAssets(AudioString.AUDIO_FILTER, new string[] { AudioString.SoundString.SOUND_EFFECT_PATH });
        clips = new AudioClip[guids.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            clips[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(AssetDatabase.GUIDToAssetPath(guids[i]));
        }
    }
}
