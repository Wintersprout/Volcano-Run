using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject[] playerPrefabs;
    [HideInInspector]
    public float scrollSpeed;
    [HideInInspector]
    public int playerSelection;
    [HideInInspector]
    public GameObject player;

    // Game flow related variables
    [HideInInspector]
    public bool gameOver;
    [HideInInspector]
    public float distanceRan = 0;
    public float distanceGoal = 2160;
    private float gameStartTime;
    private float waveTwoTriggerTime = 30;
    private float waveThreeTriggerTime = 60;

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
            new Wave(2.5f, 4.5f, WaveList.One), 
            new Wave(2, 4, WaveList.Two),
            new Wave(1.5f, 3.5f, WaveList.Three)
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

                if (Time.time > (gameStartTime + waveTwoTriggerTime) && currentWave == WaveList.One)
                {
                    // Cosmetic indicator that a new wave has started
                    CameraShake.Shake(2, 1);
                    SetupWave(waveArray[1]);
                }
                else if (Time.time > (gameStartTime + waveThreeTriggerTime) && currentWave == WaveList.Two)
                {// Cosmetic indicator that a new wave has started
                    CameraShake.Shake(2, 1);
                    SetupWave(waveArray[2]);
                }
            }
        }
    }
    /// <summary>
    /// Loads the main game scene.
    /// </summary>
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
    }
    /// <summary>
    /// Loads the Game End scene.
    /// </summary>
    public void LoadEndScene()
    {
        Destroy(player);
        DeactivateSpawners();
        SceneManager.LoadScene(2);
    }
    /// <summary>
    /// Resets game status and loads the Start menu.
    /// </summary>
    public void ReturnToStartMenu()
    {
        // Disable game over screen
        GetComponentInChildren<Canvas>().gameObject.SetActive(false);

        // Reset Player and distance
        Destroy(player);
        distanceRan = 0;

        // Disable all children and reset Object Pools
        DeactivateSpawners();

        // Load start menu
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Starts the game loop in the main scene
    /// </summary>
    public void StartGame()
    {
        // Start game
        gameOver = false;
        gameStartTime = Time.time;
        SetupWave(waveArray[0]);

        // Enable Object Pools
        player.GetComponent<PlayerController>().enabled = true;
        StartCoroutine(ActivateSpawners());
    }
        
    private void StopGame()
    {
        gameOver = true;
        // Deactivate player controls
        player.GetComponent<PlayerController>().enabled = false;
    }

    // Called by the Stamina script, when player stamina reaches zero
    public void LoseGame()
    {
        StopGame();
        
        // Display Game Over screen
        DisplayGameOverCanvas(false);

        // Lay the character dead on the floor
        player.GetComponentInChildren<Animator>().enabled = false;
        player.transform.position += Vector3.up;
        player.transform.Rotate(0, 0, 90);
    }

    // Called by the MainSceneController script after the player runs the goal distance.
    public void WinGame()
    {
        StopGame();
    }

    private IEnumerator ActivateSpawners()
    {
        var children = GetComponentsInChildren<SpawnManager>(true);

        foreach (var child in children)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }

    private void DeactivateSpawners()
    {
        var children = GetComponentsInChildren<SpawnManager>();

        foreach (var child in children)
        {
            child.gameObject.SetActive(false);
            child.RemoveAll();
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

    public void DisplayGameOverCanvas(bool win)
    {
        var canvas = GetComponentInChildren<Canvas>(true);
        var endGameText = canvas.GetComponentInChildren<TextMeshProUGUI>();

        if (win)
            endGameText.text = "YOU WIN!";
        else
            endGameText.text = "GAME OVER";

        canvas.gameObject.SetActive(true);
    }
}
