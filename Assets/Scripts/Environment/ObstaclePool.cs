using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : SpawnManager
{
    private bool isReadyToSpawn;
    private float maxDelay = 3;

    private void OnEnable()
    {
        isReadyToSpawn = true;
    }

    public override void Spawn()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 0, 20);
        activeList.Add(GetObject(location));
    }

    // Update is called once per frame
    void Update()
    {
        RemoveOutOfBounds();

        if (isReadyToSpawn)
            StartCoroutine("SpawnRoutine");
        
    }

    IEnumerator SpawnRoutine()
    {
        Spawn();
        isReadyToSpawn = false;
        yield return new WaitForSeconds(spawnDelay);
        isReadyToSpawn = true;
        RandomizeDelay();
    }

    private void RandomizeDelay()
    {
        spawnDelay = Random.Range(0, maxDelay);
    }
}
