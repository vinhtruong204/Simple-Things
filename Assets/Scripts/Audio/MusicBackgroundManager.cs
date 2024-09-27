using System.Collections;
using System.Collections.Generic;
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
}
