using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : SpawnManager
{
    //private List<GameObject> activeList;
    [SerializeField]
    private Vector3 spawnPoint;

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
        activeList.Add(this.GetObject(spawnPoint)); // Set active a new object and add to active list
    }
    /*
    private void RemoveOutOfBounds()
    {
        List<GameObject> outOfBounds = new List<GameObject>();

        // Mark spawned objects that became out of bounds...
        foreach (var obj in activeList)
        {
            if (isOutOfBounds(obj))
            {
                outOfBounds.Add(obj);
            }
        }
        // and return them to the pool, as well as removing from the active list.
        foreach (var obj in outOfBounds)
        {
            ReturnRock(obj);
        }

        outOfBounds.Clear();
    }

    public void ReturnRock(GameObject rockObject)
    {
        activeList.Remove(rockObject);
        ReturnObject(rockObject);
    }

    public bool isOutOfBounds(GameObject gameObject)
    {
        if (gameObject.transform.position.z > 5)
        {
            return true;
        }

        return false;
    }*/
}
