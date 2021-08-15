using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    private float gravityModifier = 2;

    [SerializeField]
    private GameObject[] spawnManager;

    public float scrollSpeed;
    public GameObject[] playerPrefabs;
    public int playerSelection;
    private GameObject player;

    public bool gameOver;

    public float distanceRan = 0;

    private void Awake()
    {

        if (game != null)
            Destroy(gameObject);
        else
        {
            game = this;
            DontDestroyOnLoad(game);
            Physics.gravity *= gravityModifier;
        }
    }
    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (!gameOver)
            {
                distanceRan += scrollSpeed * Time.deltaTime;
            }
        }
    }

    public void StartGame()
    {
        // Start game
        gameOver = false;
        // Instantiate selected character
        player = Instantiate(playerPrefabs[playerSelection]);
        player.transform.SetParent(transform);

        scrollSpeed = player.GetComponent<PlayerCharacter>().runSpeed;
        Debug.Log(scrollSpeed);
        // Load main scene
        SceneManager.LoadScene(1);

        // Enable Object Pools
        StartCoroutine(ActivateSpawners());
    }

    public void EndGame()
    {
        gameOver = true;
        scrollSpeed = 0;
        // Display Game Over screen
        GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
        // Deactivate player controls
        player.GetComponent<PlayerController>().enabled = false;
        // Lay the character dead on the floor
        player.GetComponentInChildren<Animator>().enabled = false;
        player.transform.position += Vector3.up;
        player.transform.Rotate(0, 0, 90);
        
    }

    public void ReturnToStartMenu()
    {
        // Disable game over screen
        GetComponentInChildren<Canvas>().gameObject.SetActive(false);

        // Reset Player and distance
        Destroy(player);
        distanceRan = 0;

        // Disable all children and reset Object Pools
        var children = GetComponentsInChildren<SpawnManager>();

        foreach (var child in children)
        {
            child.gameObject.SetActive(false);
            child.RemoveAll();
        }

        // Load start menu
        SceneManager.LoadScene(0);
    }

    private IEnumerator ActivateSpawners()
    {
        var children = GetComponentsInChildren<SpawnManager>(true);

        foreach (var child in children)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
        }
    }
}
