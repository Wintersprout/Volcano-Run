using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    /*
    [SerializeField]
    private ExplosionPool explosionPool;

    private void Start()
    {
        explosionPool = GameObject.Find("ExplosionPool").GetComponent<ExplosionPool>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosionPool.GetObject(gameObject.transform.position);
    }
    */
    
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        _ = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
    }
    
}
