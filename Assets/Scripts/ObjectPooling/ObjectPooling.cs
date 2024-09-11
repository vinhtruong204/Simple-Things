using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling
{
    private List<GameObject> pool;
    private GameObject objectPrefab;
    private Transform transformParent;
    public ObjectPooling(GameObject objectPrefab, Transform transformParent, int initialCount)
    {
        this.objectPrefab = objectPrefab;
        this.transformParent = transformParent;
        pool = new List<GameObject>();

        for (int i = 0; i < initialCount; i++)
        {
            GameObject newObject = Object.Instantiate(objectPrefab, transformParent);
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    public GameObject GetGameObject()
    {
        // Get object inactive in hierarchy
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        // Create new game object and add to pool list
        GameObject newObject = Object.Instantiate(objectPrefab, transformParent);
        pool.Add(newObject);
        return newObject;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Clear()
    {
        foreach (GameObject obj in pool)
        {
            Object.Destroy(obj);
        }
        pool.Clear();
    }

}
