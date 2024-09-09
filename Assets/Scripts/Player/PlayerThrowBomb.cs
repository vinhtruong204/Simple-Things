using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowBomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            GameObject bombPrefabs = ObjectPool.Instance.GetGameObject();
            // bombPrefabs.transform.position = transform.parent.position + new Vector3(1.5f, 1.0f, 0);
        }
    }
}
