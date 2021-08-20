using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        _ = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
    }
}
