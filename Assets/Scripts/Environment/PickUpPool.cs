using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPool : ObjectPool
{
    private List<GameObject> activeList;

    private void Start()
    {
        activeList = new List<GameObject>();
        InvokeRepeating("SpawnPickUp", 1, 2);
    }

    private void Update()
    {
        RemoveOutOfBounds();
    }

    public void SpawnPickUp()
    {
        Vector3 location = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, 10);
        activeList.Add(GetObject(location));
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
            activeList.Remove(obj);
            ReturnObject(obj);
        }

        outOfBounds.Clear();
    }

    public bool isOutOfBounds(GameObject gameObject)
    {
        if (gameObject.transform.position.z < -80)
        {
            return true;
        }

        return false;
    }
}
