using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;
    private float gravityModifier = 2;

    // Spawner related variables
    [SerializeField]
    private GameObject[] spawnManager;
    private float spawnMaxDelay;

    // Player related variables
    public float scrollSpeed;
    public GameObject[] playerPrefabs;
    public int playerSelection;
    private GameObject player;

    // Game flow related variables
    public bool gameOver;
    public float distanceRan = 0;
    private float startTime;
    private float waveTwoTriggerTime = 30;
    private float waveThreeTriggerTime = 45;

    // States that control obstacle spawn frequency range
    private enum Wave
    {
        One,
        Two,
        Three
    }

    private Wave currentWave = Wave.One;

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

                if (Time.time > (startTime + waveTwoTriggerTime) && currentWave == Wave.One)
                    IncreaseWave(1, 2, 0.5f);
                else if (Time.time > (startTime + waveThreeTriggerTime) && currentWave == Wave.Two)
                    IncreaseWave(1, 2, 1);
            }
        }
    }

    public void StartGame()
    {
        // Start game
        gameOver = false;
        startTime = Time.time;
        // Instantiate selected character
        player = Instantiate(playerPrefabs[playerSelection]);
        player.transform.SetParent(transform);
        // Set up screen scroll speed
        scrollSpeed = player.GetComponent<PlayerCharacter>().runSpeed;

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

    private void IncreaseWave(float delayDecrement, float shakeDuration, float shakeIntensity)
    {
        var spawns = GetComponentsInChildren<SpawnManager>();

        foreach (var spawn in spawns)
        {
            spawn.spawnMaxDelay -= delayDecrement;
        }

        CameraShake.Shake(shakeDuration, shakeIntensity);

        currentWave++; 
    }
}
