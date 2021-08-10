using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPool : ObjectPool
{
    private void Start()
    {
        InvokeRepeating("SpawnMagma", 1.5f, 1);
    }

    private void SpawnMagma()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 30, Random.Range(-30, 0));
        _ = GetObject(location);
    }
}
