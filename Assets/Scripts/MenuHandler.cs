using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    private ToggleGroup characterSelector;
    [SerializeField]
    private GameObject[] characterModels;

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
        characterModels[0].SetActive(true);
        characterModels[1].SetActive(false);
        characterModels[2].SetActive(false);
    }
    public void SelectCharacterTwo()
    {
        GameManager.game.playerSelection = 1;
        characterModels[0].SetActive(false);
        characterModels[1].SetActive(true);
        characterModels[2].SetActive(false);
    }
    public void SelectCharacterThree()
    {
        GameManager.game.playerSelection = 2;
        characterModels[0].SetActive(false);
        characterModels[1].SetActive(false);
        characterModels[2].SetActive(true);
    }
}
