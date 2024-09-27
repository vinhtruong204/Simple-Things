using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public abstract class SoundManager : MonoBehaviour
{

    [SerializeField]
    protected Sound[] sounds;

    protected AudioSource audioSource;

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        LoadSound();
    }

    protected void LoadSound()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = audioSource;
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.playOnAwake;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        sound.audioSource.Play();
    }
}
