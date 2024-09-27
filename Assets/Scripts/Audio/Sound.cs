using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume = 1.0f;

    [Range(0.0f, 3.0f)]
    public float pitch = 1.0f;

    public AudioSource audioSource;

    public bool loop;

    public bool playOnAwake;

    public string name;


}
