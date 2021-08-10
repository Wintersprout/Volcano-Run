using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    public static float scrollSpeed;
    [SerializeField]
    protected float jumpForce = 5;

    protected bool isOnGround = true;

    protected Rigidbody playerRb;
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public virtual void Jump(float horizontalInput, float verticalInput)
    {
        Vector3 jumpVector = new Vector3(horizontalInput, 1, verticalInput) * jumpForce;
        
        if (isOnGround)
        {
            playerRb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }

    public virtual void Move(float horizontalInput, float verticalInput)
    {
        if (isOnGround)
        {
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    public abstract void SpecialAbility();

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    protected virtual void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
