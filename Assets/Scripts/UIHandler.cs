using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Stamina playerStamina;
    private  Slider staminaBar;
    private Text distanceText;
    // Start is called before the first frame update
    void Start()
    {
        playerStamina = FindObjectOfType<Stamina>().GetComponent<Stamina>();
        
        distanceText = GetComponentInChildren<Text>();
        staminaBar = GetComponentInChildren<Slider>();
        staminaBar.maxValue = Stamina.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.currentStamina;
        distanceText.text = $"Distance: {Mathf.Floor(GameManager.game.distanceRan)}m";
    }
}
