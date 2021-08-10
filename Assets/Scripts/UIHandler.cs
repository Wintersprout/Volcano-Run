using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Stamina playerStamina;
    private  Slider staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        playerStamina = FindObjectOfType<Stamina>().GetComponent<Stamina>();
        //playerStamina = GameObject.Find("Player").GetComponent<Stamina>();
        staminaBar = GetComponentInChildren<Slider>();
        staminaBar.maxValue = playerStamina.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.currentStamina;
    }
}
