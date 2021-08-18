using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<ParticleSystem>().Play(true);
    }
    private void OnDisable()
    {
        GetComponentInParent<ObjectPool>().ReturnObject(this.gameObject);
    }
}
