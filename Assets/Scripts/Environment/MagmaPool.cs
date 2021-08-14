using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPool : SpawnManager
{
    private void OnEnable()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnFrequency);
    }

    private void Update()
    {
        RemoveOutOfBounds();
    }

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 30, Random.Range(-30, 0));
        //_ = GetObject(location);
        activeList.Add(GetObject(location));
    }
}
