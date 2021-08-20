using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Stamina playerStamina;
    
    [SerializeField]
    private Slider staminaBar;
    [SerializeField]
    private Slider distanceBar;
    private Color staminaColor = new Color(0, 0.5f, 0.06f);
    private Color lowStaminaColor = Color.red;


    private float lowStaminaMark = 0.25f;
    
    void Start()
    {
        playerStamina = FindObjectOfType<Stamina>().GetComponent<Stamina>();
        
        staminaBar.maxValue = playerStamina.maxStamina;
        distanceBar.maxValue = GameManager.game.distanceGoal;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.currentStamina;
        distanceBar.value = GameManager.game.distanceRan;
    }

    public void LowStaminaDisplay()
    {
        // Exact location of the stamina bar fill. May break if hierarchy is changed.
        var fill = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();

        /* Same as above. It takes a little more processing, but it is safer.
         * 
        var images = staminaBar.gameObject.GetComponentsInChildren<Image>();
        Image fill = null;
        
        foreach (var image in images)
        {
            if (image.gameObject.name == "Fill")
                fill = image;
        }
        */
        if (fill == null)
            return;

        if (playerStamina.currentStamina < playerStamina.maxStamina * lowStaminaMark)
        {            
            fill.color = lowStaminaColor;
        }
        else
        {
            fill.color = staminaColor;
        }
    }
}
