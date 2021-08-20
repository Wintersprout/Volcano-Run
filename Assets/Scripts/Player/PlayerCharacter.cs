using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    [HideInInspector]
    public float runSpeed;

    protected float zBackBound = -80, zForwardBound = 10;

    [HideInInspector]
    public bool isOnGround;

    protected Rigidbody playerRb;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        AvoidFallingThroughTheFloor();
        CheckBounds();
    }

    public virtual void Move(float horizontalInput, float verticalInput)
    {
        //if (isOnGround)
        {
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
            playerRb.MovePosition(transform.position + movement);
            // Children goes together, meaning the bomb of human character would travel together with player
            //transform.Translate(movement); 
        }
    }

    public abstract void SpecialAbility();
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal.normalized == Vector3.up)
        {
            isOnGround = true;
        }
    }
    protected virtual void OnCollisionExit(Collision collision)
    {
        
        //if (collision.contactCount > 0)
        {
            //if (collision.GetContact(0).normal.normalized == Vector3.up)
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = false;
            }
        }
    }

    protected virtual void AvoidFallingThroughTheFloor()
    {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    protected virtual void CheckBounds()
    {
        if (transform.position.z < zBackBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBackBound);
        }
        else if (transform.position.z > zForwardBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zForwardBound);
        }
    }
}
