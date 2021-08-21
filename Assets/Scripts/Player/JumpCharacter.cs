using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharacter : PlayerCharacter
{
    [SerializeField]
    protected float jumpForce = 10;

    protected override void Awake()
    {
        base.Awake();
        runSpeed = 20;
    }

    public override void SpecialAbility()
    {
        Vector3 jumpVector = new Vector3(playerRb.velocity.x, 1, playerRb.velocity.z) * jumpForce;

        if (isOnGround)
        {
            if (playerAudio != null)
                playerAudio.Play();
            playerRb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }
}
