using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    private ToggleGroup characterSelector;

    private void Awake()
    {
        characterSelector = GetComponentInChildren<ToggleGroup>();
    }

    public void StartGame()
    {
        GameManager.game.StartGame();
    }

    public void SelectCharacterOne()
    {
        GameManager.game.playerSelection = 0;
        GameManager.game.scrollSpeed = 10;
    }
    public void SelectCharacterTwo()
    {
        GameManager.game.playerSelection = 1;
        GameManager.game.scrollSpeed = 15;
    }
    public void SelectCharacterThree()
    {
        GameManager.game.playerSelection = 2;
        GameManager.game.scrollSpeed = 20;
    }
}
