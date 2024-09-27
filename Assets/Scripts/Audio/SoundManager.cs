using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public abstract class SoundManager : MonoBehaviour
{

    [SerializeField]
    protected AudioClip[] clips;

    [SerializeField]
    protected AudioSource audioSource;

    protected void Awake()
    {
        LoadComponents();
        LoadAudioClips();
    }

    private void LoadComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {
        AudioClip clip = Array.Find(clips, clip => clip.name == name);

        if (clip == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }

    protected abstract void LoadAudioClips();
}
