using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPool : SpawnManager
{
    // Spawn area bounds
    private float spawnX = 10, spawnY = 0.5f, spawnZ = 10;
    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-spawnX, spawnX), spawnY, spawnZ);
        activeList.Add(GetFromPool(location));
    }
}
