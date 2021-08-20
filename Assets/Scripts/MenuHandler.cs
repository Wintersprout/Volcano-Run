using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterModels;

    public void StartGame()
    {
        GameManager.game.LoadMainScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SelectCharacterOne()
    {
        SetUpCharacter(0);
    }
    public void SelectCharacterTwo()
    {
        SetUpCharacter(1);
    }
    public void SelectCharacterThree()
    {
        SetUpCharacter(2);
    }

    private void SetUpCharacter(int characterIndex)
    {
        GameManager.game.playerSelection = characterIndex;

        for (int i = 0; i < characterModels.Length; i++)
        {
            if (i != characterIndex)
                characterModels[i].SetActive(false);
            else
                characterModels[i].SetActive(true);
        }
    }
}
