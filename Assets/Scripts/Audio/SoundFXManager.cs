using System.Collections;
using System.Collections.Generic;
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
}
