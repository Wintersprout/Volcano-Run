using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    private float outroMovementSpeed = 10;
    private float introEndPosition = 0;
    private float outroEndPosition = 20;
    
    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    private void Update()
    {
        if (!GameManager.game.gameOver && GameManager.game.distanceRan >= GameManager.game.distanceGoal)
        {
            GameManager.game.WinGame();
            StartCoroutine(PlayOutro());
        }
    }

    IEnumerator PlayIntro()
    {
        GameObject player = GameManager.game.player;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, GameManager.game.scrollSpeed);

        while (player.transform.position.z < introEndPosition)
        {
            yield return null;
        }
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        GameManager.game.StartGame();
    }

    IEnumerator PlayOutro()
    {
        GameObject player = GameManager.game.player;
        // Win Animation
        player.GetComponent<PlayerCharacter>().enabled = false;
        player.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, outroMovementSpeed);

        while (player.transform.position.z < outroEndPosition)
        {
            yield return null;
        }
        GameManager.game.LoadEndScene();
    }
}
