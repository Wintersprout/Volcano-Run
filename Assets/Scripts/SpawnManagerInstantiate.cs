using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private float xNegativeBound, xPositiveBound, yNegativeBound, yPositiveBound, zNegativeBound, zPositiveBound;
    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity *= 3;

        InvokeRepeating("SpawnObject", 1.5f, 2);
    }

    public void SpawnObject()
    {
        float xSpawnPos = Random.Range(xNegativeBound, xPositiveBound);
        float ySpawnPos = Random.Range(yNegativeBound, yPositiveBound);
        float zSpawnPos = Random.Range(zNegativeBound, zPositiveBound);
        Vector3 location = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);

        Instantiate(objectPrefab, location, Quaternion.identity).transform.SetParent(this.transform);
    }
}
