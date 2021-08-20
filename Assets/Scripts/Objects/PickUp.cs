using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Range(10, 30)]
    public float restoreRate;

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<ObjectPool>().ReturnToPool(gameObject);
    }
}
