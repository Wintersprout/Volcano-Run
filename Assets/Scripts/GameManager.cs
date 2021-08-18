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

    // Player related variables
    public float scrollSpeed;
    public GameObject[] playerPrefabs;
    public int playerSelection;
    public GameObject player;

    // Game flow related variables
    public bool gameOver;
    public float distanceRan = 0;
    public float distanceGoal = 2000;
    private float startTime;
    private float waveTwoTriggerTime = 30;
    private float waveThreeTriggerTime = 45;

    // States that indicate obstacle spawn frequency
    private enum WaveList
    {
        One,
        Two,
        Three
    }
    // Wave related variables
    private struct Wave
    {
        private readonly float obstacleSpawnMaxDelay;
        private readonly float pickUpSpawnMaxDelay;
        private readonly WaveList waveNumber;
        
        public Wave(float obstacleDelay, float pickupDelay, WaveList waveNumber) : this()
        {
            this.obstacleSpawnMaxDelay = obstacleDelay;
            this.pickUpSpawnMaxDelay = pickupDelay;
            this.waveNumber = waveNumber;
        }

        public float ObstacleSpawnMaxDelay { get {return obstacleSpawnMaxDelay; } }
        public float PickUpSpawnMaxDelay { get { return pickUpSpawnMaxDelay; } }
        public WaveList WaveNumber { get { return waveNumber; } }
    }

    private readonly Wave[] waveArray = 
        new Wave[] 
        {
            new Wave(2.5f, 5, WaveList.One), 
            new Wave(2, 4, WaveList.Two),
            new Wave(1.5f, 3, WaveList.Three)
        };

    private WaveList currentWave;

    private void Awake()
    {

        if (game != null)
            Destroy(gameObject);
        else
        {
            game = this;
            DontDestroyOnLoad(game);
            Physics.gravity *= gravityModifier;
            gameOver = true;
        }
    }
    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (!gameOver)
            {
                distanceRan += scrollSpeed * Time.deltaTime;

                if (Time.time > (startTime + waveTwoTriggerTime) && currentWave == WaveList.One)
                {
                    // Cosmetic indicator that a new wave has started
                    CameraShake.Shake(2, 1);
                    SetupWave(waveArray[1]);
                }
                else if (Time.time > (startTime + waveThreeTriggerTime) && currentWave == WaveList.Two)
                {// Cosmetic indicator that a new wave has started
                    CameraShake.Shake(2, 1);
                    SetupWave(waveArray[2]);
                }
            }
        }
    }

    public void LoadMainScene()
    {
        // Instantiate selected character
        player = Instantiate(playerPrefabs[playerSelection]);
        player.transform.SetParent(transform);
        player.GetComponent<PlayerController>().enabled = false;
        // Set up screen scroll speed
        scrollSpeed = player.GetComponent<PlayerCharacter>().runSpeed;

        // Load main scene
        SceneManager.LoadScene(1);

        //StartGame();
    }

    public void StartGame()
    {
        // Start game
        gameOver = false;
        startTime = Time.time;
        SetupWave(waveArray[0]);

        // Enable Object Pools
        player.GetComponent<PlayerController>().enabled = true;
        StartCoroutine(ActivateSpawners());
    }

    public void EndGame()
    {
        gameOver = true;
        // Display Game Over screen
        GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
        // Deactivate player controls
        player.GetComponent<PlayerController>().enabled = false;
        // Lay the character dead on the floor
        if (player.GetComponent<Stamina>().currentStamina <= 0) // Lose the game
        {
            player.GetComponentInChildren<Animator>().enabled = false;
            player.transform.position += Vector3.up;
            player.transform.Rotate(0, 0, 90);
        }
        else // Win the Game
        {
            player.GetComponent<PlayerCharacter>().enabled = false;
            player.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
        }
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
            yield return new WaitForSeconds(1);
        }
    }

    private void SetupWave(Wave wave)
    {
        var spawns = GetComponentsInChildren<SpawnManager>(true);

        foreach (var spawn in spawns)
        {
            if (spawn.gameObject.GetComponent<PickUpPool>() == null)
                spawn.spawnMaxDelay = wave.ObstacleSpawnMaxDelay;
            else
                spawn.spawnMaxDelay = wave.PickUpSpawnMaxDelay;
        }

        currentWave = wave.WaveNumber; 
    }
}
