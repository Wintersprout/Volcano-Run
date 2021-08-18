using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        GameObject player = GameManager.game.player;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, GameManager.game.scrollSpeed);
        Debug.Log(player.GetComponent<Rigidbody>().velocity);

        while (player.transform.position.z < 0)
        {
            yield return null;
        }
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        GameManager.game.StartGame();
    }
}
