using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryAnimation : MonoBehaviour
{
    private float displayTime = 5;
    private float transitionTime = 1.5f;

    [SerializeField]
    private GameObject[] player;
    private TextMeshProUGUI dialogText;

    private readonly string[,] dialog =
    {
        {
            "Phew, that was a close one!",
            "Now... How exactly did I end up near an active volcano anyway?",
            "What a crazy night..."
        },
        {
            "Phew... that was a close one!",
            "That must have scared away that fox.",
            "I guess it didn't see that coming, huh?"
        },
        {
            "Phew... that was close!",
            "Now, next time we are hunting...",
            "Remember not to chase your food into an active volcano."
        }
    };

    private void Start()
    {
        player[GameManager.game.playerSelection].SetActive(true);
        dialogText = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(StartEndingScene());
    }


    private IEnumerator StartEndingScene()
    {
        yield return new WaitForSeconds(transitionTime);

        for (int i = 0; i < dialog.GetLength(1); i++)
        {    
            dialogText.text = dialog[GameManager.game.playerSelection, i];
            yield return new WaitForSeconds(displayTime);
            dialogText.text = "";
            yield return new WaitForSeconds(transitionTime);
        }

        GameManager.game.DisplayGameOverCanvas(true);
    }
}
