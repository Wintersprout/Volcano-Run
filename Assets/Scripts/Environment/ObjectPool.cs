using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] objectPrefab;
    protected Queue<GameObject> objectQueue;
    [SerializeField]
    private int poolSize;

    protected virtual void Awake()
    {
        objectQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            int index = Random.Range(0, objectPrefab.Length);
            GameObject gameObject = Instantiate(objectPrefab[index]);
            gameObject.SetActive(false);
            //gameObject.name = i.ToString();
            objectQueue.Enqueue(gameObject);
            gameObject.transform.SetParent(this.transform);
        }
    }
    /// <summary>
    /// Returns an object from the pool at the given location.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public GameObject GetFromPool(Vector3 location)
    {
        GameObject gameObject = objectQueue.Dequeue();
        gameObject.transform.position = location;
        gameObject.SetActive(true);
        return gameObject;
    }
    /// <summary>
    /// Deactivates the given object and returns it to the pool. 
    /// </summary>
    /// <param name="gameObject"></param>
    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        objectQueue.Enqueue(gameObject);
    }

}
