using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Range(1, 3)]
    public float restoreRate;

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<ObjectPool>().ReturnObject(gameObject);
    }
}
