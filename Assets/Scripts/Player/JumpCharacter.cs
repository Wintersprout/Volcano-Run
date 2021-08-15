using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharacter : PlayerCharacter
{
    //private bool isDoubleJumping = false;
    [SerializeField]
    protected float jumpForce = 10;

    protected override void Awake()
    {
        base.Awake();
        runSpeed = 20;
    }
    /*
    public override void Jump(float horizontalInput, float verticalInput)
    {
        base.Jump(horizontalInput, verticalInput);
        
        if (!isDoubleJumping && !isOnGround)
        {
            playerRb.velocity = Vector3.zero; // Ignores current speed on the new jump;
            Vector3 jumpVector = new Vector3(horizontalInput, 1, verticalInput) * jumpForce;
            playerRb.AddForce(jumpVector, ForceMode.Impulse);
            isDoubleJumping = true;
        }
    }
    */
    public override void SpecialAbility()
    {
        Vector3 jumpVector = new Vector3(playerRb.velocity.x, 1, playerRb.velocity.z) * jumpForce;

        if (isOnGround)
        {
            playerRb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }
    /*
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.GetContact(0).normal.normalized == Vector3.up)
        //if (collision.gameObject.CompareTag("Ground"))
        {
            isDoubleJumping = false;
        }
    }
    */
}
