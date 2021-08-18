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

    //private Text distanceText;

    private float lowStaminaMark = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        playerStamina = FindObjectOfType<Stamina>().GetComponent<Stamina>();
        
        //distanceText = GetComponentInChildren<Text>();
        staminaBar.maxValue = Stamina.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = playerStamina.currentStamina;
        //distanceText.text = $"Distance: {Mathf.Floor(GameManager.game.distanceRan)}m";
        distanceBar.value = GameManager.game.distanceRan;
        distanceBar.maxValue = GameManager.game.distanceGoal;

        if (distanceBar.value >= distanceBar.maxValue)
            GameManager.game.EndGame();
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

        if (playerStamina.currentStamina < Stamina.maxStamina * lowStaminaMark)
        {            
            fill.color = new Color(1, 0, 0);
        }
        else
        {
            fill.color = new Color(0, 0.5f, 0.06f);
        }
    }
}
