using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private bool BringBackToStart;

    private float startingZPos = 15;
    private float endingZPos = -180;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.game.gameOver)
        {
            transform.Translate(Vector3.back * GameManager.game.scrollSpeed * Time.deltaTime, Space.World);

            // Move object to the front of the screen so it can be visible again
            if (BringBackToStart)
            {
                Vector3 origin = new Vector3(transform.position.x, transform.position.y, startingZPos);
                if (transform.position.z < endingZPos)
                    transform.position = origin;
            }
        }
    }
}
