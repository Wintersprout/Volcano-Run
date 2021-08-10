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

    // Update is called once per frame
    void Update()
    {
        horizontalInput = -Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");

        player.Move(horizontalInput, verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump(horizontalInput, verticalInput);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            player.SpecialAbility();
        }
    }
}
