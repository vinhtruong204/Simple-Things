using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    public void SpawnObject();
    public void DeSpawnObject(GameObject obj);
}
