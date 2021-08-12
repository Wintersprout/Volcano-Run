using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Stamina playerStamina;
    private  Slider staminaBar;
    //private Text staminaText;
    // Start is called before the first frame update
    void Start()
    {
        playerStamina = FindObjectOfType<Stamina>().GetComponent<Stamina>();
        //playerStamina = GameObject.Find("Player").GetComponent<Stamina>();
        //staminaText = GetComponentInChildren<Text>();
        staminaBar = GetComponentInChildren<Slider>();
        staminaBar.maxValue = Stamina.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.currentStamina;
        //staminaText.text = playerStamina.gameObject.GetComponent<PlayerCharacter>().isOnGround.ToString();//playerStamina.currentStamina.ToString();
    }
}
