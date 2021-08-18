using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private bool BringBackToFront;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.game.gameOver)
        {
            transform.Translate(Vector3.back * GameManager.game.scrollSpeed * Time.deltaTime, Space.World);

            if (BringBackToFront)
            {
                Vector3 origin = new Vector3(transform.position.x, transform.position.y, 15);
                if (transform.position.z < -180)
                    transform.position = origin;
            }
        }
    }
}
