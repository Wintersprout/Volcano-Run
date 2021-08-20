using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody bombRb;
    private float yOffset = 1.5f, zOffset = -2.5f;
    private Vector3 trajectoryAngle = new Vector3(0, 0.5f, -1).normalized;

    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Throw();
    }
    /// <summary>
    /// Resets the bomb's position and velocity.
    /// </summary>
    public void Reset()
    {
        Vector3 position = GetComponentInParent<Transform>().position;
        
        bombRb.velocity = Vector3.zero;
        transform.position = new Vector3(position.x, position.y + yOffset, position.z + zOffset);
    }

    private void Throw()
    {
        bombRb.AddForce(trajectoryAngle * moveSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
