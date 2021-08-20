using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float angularSpeed = 180;

    void Update()
    {
        transform.Rotate(Vector3.up, angularSpeed * Time.deltaTime);
    }
}
