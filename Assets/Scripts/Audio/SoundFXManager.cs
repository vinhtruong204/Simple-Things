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
            PlaySound("Collect");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound("EnemyAttack");
        }
    }

    protected override void LoadAudioClips()
    {
        string[] guids = AssetDatabase.FindAssets("t:AudioClip", new string[] { "Assets/Audio/SoundEffect" });
        clips = new AudioClip[guids.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            clips[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(AssetDatabase.GUIDToAssetPath(guids[i]));
        }
    }
}
