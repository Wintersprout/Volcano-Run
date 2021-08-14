using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnManager : ObjectPool
{
    protected List<GameObject> activeList; // Pool objects that are currently active

    protected float zLowerBound = -180, zUpperBound = 20;
    protected float yLowerBound = -5, yUpperBound = 50;
    protected float xLowerBound = -30, xUpperBound = 30;

    [SerializeField]
    protected float spawnDelay = 1, spawnFrequency = 1;

    protected override void Awake()
    {
        base.Awake();
        activeList = new List<GameObject>();
    }

    protected virtual void OnDisable()
    {
        CancelInvoke();
    }

    public abstract void Spawn();


    protected virtual void RemoveOutOfBounds()
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
            Remove(obj);
        }

        outOfBounds.Clear();
    }

    protected virtual bool isOutOfBounds(GameObject gameObject)
    {
        if (gameObject.transform.position.z < zLowerBound ||
            gameObject.transform.position.z > zUpperBound ||
            gameObject.transform.position.y < yLowerBound ||
            gameObject.transform.position.y > yUpperBound ||
            gameObject.transform.position.x < xLowerBound ||
            gameObject.transform.position.x > xUpperBound)
        {
            return true;
        }

        return false;
    }

    public void Remove(GameObject obj)
    {
        activeList.Remove(obj);
        ReturnObject(obj);
        //Debug.Log($"Returning object {obj.name}");
    }

    public void RemoveAll()
    {
        List<GameObject> toBeRemoved = new List<GameObject>();

        foreach (var obj in activeList)
            toBeRemoved.Add(obj);
        foreach (var obj in toBeRemoved)
            Remove(obj);
    }
}
