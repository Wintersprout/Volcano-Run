using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerCharacter player;
    private float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Stamina>().GetComponent<PlayerCharacter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.Jump(horizontalInput, verticalInput);
            player.SpecialAbility();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            CameraShake.Shake(1, 1);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = -Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");

        player.Move(horizontalInput, verticalInput);

    }
}
