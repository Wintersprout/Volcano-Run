using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCharacter : PlayerCharacter
{
    private bool isDashing = false;
    public float dashSpeed = 5;
    public float dashDuration = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        runSpeed = 24;
    }

    public override void Move(float horizontalInput, float verticalInput)
    {
        if (isDashing)
        {   // Rounding up the input
            if (horizontalInput > 0)
                horizontalInput = 1;
            else if (horizontalInput < 0)
                horizontalInput = -1;

            if (verticalInput > 0)
                verticalInput = 1;
            else if (verticalInput < 0)
                verticalInput = -1;
        }
        base.Move(horizontalInput, verticalInput);
    }

    public override void SpecialAbility()
    {
        if (!isDashing)
        {
            if(playerAudio != null)
                playerAudio.Play();
            StartCoroutine("DashCounter");
        }
    }

    private IEnumerator DashCounter()
    {
        isDashing = true;
        moveSpeed *= dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        moveSpeed /= dashSpeed;
        isDashing = false;
    }
}
