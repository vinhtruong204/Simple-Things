using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooling : MonoBehaviour
{
    protected List<GameObject> pool;
    protected GameObject objectPrefab;
    protected Transform transformParent;

    protected void InitialPool(int initialCount)
    {
        pool = new List<GameObject>();

        for (int i = 0; i < initialCount; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transformParent);
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
        GameObject newObject = Instantiate(objectPrefab, transformParent);
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
            Destroy(obj);
        }
        pool.Clear();
    }

}
