using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : SpawnManager
{
    // Spawn area bounds
    private float spawnX = 10, spawnY = 0, spawnZ = 20;

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-spawnX, spawnX), spawnY, spawnZ);
        activeList.Add(GetFromPool(location));
    }

}
