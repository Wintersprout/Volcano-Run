using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectPrefab;
    protected Queue<GameObject> objectQueue;
    [SerializeField]
    private int poolSize;

    protected virtual void Awake()
    {
        objectQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(objectPrefab);
            gameObject.SetActive(false);
            objectQueue.Enqueue(gameObject);
            gameObject.transform.SetParent(this.transform);
        }
    }

    public GameObject GetObject(Vector3 location)
    {
        GameObject gameObject = objectQueue.Dequeue();
        gameObject.transform.position = location;
        gameObject.SetActive(true);

        return gameObject;
    }

    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        objectQueue.Enqueue(gameObject);
    }

}
