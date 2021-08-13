using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public float scrollSpeed;
    public GameObject[] playerCharacter;
    public int playerCharacterSelection;

    private void Awake()
    {
        if (game != null)
            Destroy(gameObject);
        else
        {
            game = this;
            DontDestroyOnLoad(game);
        }
    }

    public void StartGame()
    {
        var player = Instantiate(playerCharacter[playerCharacterSelection]);
        player.transform.SetParent(transform);
        SceneManager.LoadScene(1);
    }
}
