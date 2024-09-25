using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEditor.PackageManager;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance { get; private set; }

    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }
    }

    public void PlaySound(string soundName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);

        sound.audioSource.Play();
    }
}
