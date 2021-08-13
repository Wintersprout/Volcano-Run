using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    private float gravityModifier = 2;

    public float scrollSpeed;
    public GameObject[] playerCharacter;
    public int playerCharacterSelection;
    private GameObject player;

    public bool gameOver;

    public float distanceRan = 0;

    private void Awake()
    {
        Physics.gravity *= gravityModifier;

        if (game != null)
            Destroy(gameObject);
        else
        {
            game = this;
            DontDestroyOnLoad(game);
        }
    }

    private void Update()
    {
        if (!gameOver)
        {
            distanceRan += scrollSpeed * Time.deltaTime;
        }
        else
        {
            scrollSpeed = 0;
            GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void StartGame()
    {
        player = Instantiate(playerCharacter[playerCharacterSelection]);
        player.transform.SetParent(transform);
        SceneManager.LoadScene(1);

        // Enable Object Pools
        var children = GetComponentsInChildren<SpawnManager>(true);

        foreach (var child in children)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void ReturnToStartMenu()
    {
        Destroy(player);
        distanceRan = 0;
        gameOver = false;

        // Disable all children and reset Object Pools
        var children = GetComponentsInChildren<SpawnManager>();

        foreach (var child in children)
        {
            child.gameObject.SetActive(false);
            child.RemoveAll();
        }

        GetComponentInChildren<Canvas>().gameObject.SetActive(false);

        SceneManager.LoadScene(0);
    }
}
