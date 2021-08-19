using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryAnimation : MonoBehaviour
{
    private float displayTime = 5;
    private float transitionTime = 2;

    [SerializeField]
    private GameObject[] player;
    private TextMeshProUGUI dialogText;

    private readonly string[,] dialog =
    {
        {
            "Now... How exactly did I end up near an active volcano anyway?",
            "What a crazy night..."
        },
        {
            "I would pay high money to see that fox's face when the volcano erupted...",
            "I guess it didn't see that coming, huh?"
        },
        {
            "Note to self: never chase your food in to an active volcano.",
            "It is never worth the trouble, no matter how delicious it looks."
        }
    };

    private void Start()
    {
        player[GameManager.game.playerSelection].SetActive(true);
        dialogText = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(StartEndingDialog());
    }


    private IEnumerator StartEndingDialog()
    {
        
        for (int i = 0; i < dialog.GetLength(1); i++)
        {
            yield return new WaitForSeconds(transitionTime);
            dialogText.text = dialog[GameManager.game.playerSelection, i];
            yield return new WaitForSeconds(displayTime);
            dialogText.text = "";
        }
    }
}
