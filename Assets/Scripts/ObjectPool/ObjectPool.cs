using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }
    private List<GameObject> pool;
    private GameObject bombPrefab;
    private readonly int initialCount = 10;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        pool = new List<GameObject>();
        bombPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bomb.prefab");

        for (int i = 0; i < initialCount; i++)
        {
            GameObject obj = Instantiate(bombPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetGameObject()
    {
        // Get object inactive in hierarchy
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        // Create new game object and add to pool list
        GameObject obj = Instantiate(bombPrefab);
        pool.Add(obj);
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Clear()
    {
        foreach (GameObject obj in pool)
        {
            Destroy(obj);
        }
        pool.Clear();
    }

}
