using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCharacter : PlayerCharacter
{
    private bool isFloating = false;
    [SerializeField]
    private float floatMaxDuration = 1.2f;
    private float floatForce = 3.5f;

    private void Start()
    {
        scrollSpeed = 10;
    }

    public override void SpecialAbility()
    {
        if(!isOnGround && playerRb.velocity.y < 0)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isFloating)
        {
            StartCoroutine(FloatCounter(floatMaxDuration));
        }
        if (Input.GetKey(KeyCode.B) && isFloating)
        {
            SpecialAbility();
        }
    }

    private IEnumerator FloatCounter(float duration)
    {
        isFloating = true;
        yield return new WaitForSeconds(duration);
        isFloating = false;
    }
}
