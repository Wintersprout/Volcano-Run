using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : SpawnManager
{
    [SerializeField]
    private Vector3 spawnPoint;

    public override void Spawn()
    {
        activeList.Add(this.GetFromPool(spawnPoint)); // Set active a new object and add to active list
    }

}
