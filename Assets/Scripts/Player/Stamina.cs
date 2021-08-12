using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    public const float maxStamina = 10;
    public float currentStamina;
    [SerializeField]
    private float decreaseRate;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        LoseStamina(decreaseRate * Time.deltaTime);
    }

    public void LoseStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina <= 0)
        {
            //Game Over
        }
    }

    public void RecoverStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {  
        var obstacle = collision.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
            LoseStamina(obstacle.damageRate);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
            RecoverStamina(other.GetComponent<PickUp>().restoreRate);
    }
}
