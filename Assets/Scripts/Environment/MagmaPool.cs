using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPool : SpawnManager
{
    private void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnFrequency);
    }

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 30, Random.Range(-30, 0));
        _ = GetObject(location);
    }
}
