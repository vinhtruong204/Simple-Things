using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract void SpawnObject();

    public abstract void DeSpawnObject(GameObject obj);
}

