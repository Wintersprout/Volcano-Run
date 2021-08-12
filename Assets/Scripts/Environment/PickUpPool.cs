using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPool : SpawnManager
{

    private void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnFrequency);
    }

    private void Update()
    {
        RemoveOutOfBounds();
    }

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, 10);
        activeList.Add(GetObject(location));
    }
}
