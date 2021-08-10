using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : ObjectPool
{
    private List<GameObject> activeList;
    [SerializeField]
    private Vector3 spawnPoint;

    private void Start()
    {
        activeList = new List<GameObject>();
        Physics.gravity *= 2;
        InvokeRepeating("SpawnRock", 1, 1);
    }

    private void Update()
    {
        RemoveOutOfBounds();
    }

    public void SpawnRock()
    {
        activeList.Add(this.GetObject(spawnPoint)); // Set active a new object and add to active list
    }

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
    }
}
