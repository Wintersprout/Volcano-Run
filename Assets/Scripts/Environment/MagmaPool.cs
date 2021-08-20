using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPool : SpawnManager
{
    // Spawn area bounds
    private float spawnX = 10, spawnY = 30, spawnZBack = -40, spawnZForward = 0;

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-spawnX, spawnX),
                                                    spawnY, 
                                                    Random.Range(spawnZBack, spawnZForward));
        activeList.Add(GetFromPool(location));
    }
}
