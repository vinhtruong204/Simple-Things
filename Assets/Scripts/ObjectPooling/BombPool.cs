using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public static BombPool Instance { get; private set; }
    public ObjectPooling BombPooling { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameObject bombPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bomb.prefab");
        int initialCount = 10;
        BombPooling = new ObjectPooling(bombPrefab, transform, initialCount);
    }

}
